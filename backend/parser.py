from bs4 import BeautifulSoup
import requests
import csv
from json_parser import car_iter
from text_utils import normalize

"""
    Web scraping module for collecting car listings from automobile.it.
    - HEADERS and BASE_URL: define user-agent and base website URL for requests.
    - target_parameters: list of car attributes to extract from each listing.
    - build_url: constructs a URL for a given car make, model, and page number.
    - parse_data: main function that iterates over all makes/models, navigates pages,
      retrieves HTML content, parses relevant fields with BeautifulSoup, and writes
      the collected data into a CSV file (data/raw_data.csv). Handles missing pages
      and partial results gracefully, logging progress for each car and page.
"""

HEADERS = {'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.77 Safari/537.36 Edg/91.0.864.37'}

BASE_URL = "https://www.automobile.it"

# All the data we want to get
target_parameters = ('Tipologia',
                     'Brand', # not to be parsed
                     'Model', # not to be parsed
                     'Versione',
                     'Carburante',
                     'Chilometri',
                     'Immatricolazione',
                     'Cambio',
                     'Potenza',
                     'Regione',
                     'Price')

def build_url(brand, model, page_number: int):
    car_name = normalize(f'{brand}-{model}')
    url = f"{BASE_URL}/{car_name}/page-{page_number}"
    return url

def parse_data():
    print("Starting parsing data...")
    with open("data/raw_data.csv", "a", newline="", encoding="utf-8") as f: # It's too nested, but needed, otherwise we risk wasting a couple of hours worth of data
        writer = None
        for make, model in car_iter():
            print(f'Searching {make} {model}.')
            for page in range(1,501): # 500 is the maximum amount of pages. It might be less, but the error will be caught.
                url = build_url(make, model, page)
                resp = requests.get(url, headers=HEADERS, timeout=60)

                if resp.status_code == 404:
                    print(f"Page {page} does not exist. Skipping to next make/model")
                    break
                else:
                    mainpage_soup = BeautifulSoup(resp.content, 'html.parser')

                # Getting all the car ads on current page
                car_ads = mainpage_soup.find_all(class_='jsx-f2b46c5d98b3a3b2 Card hover-effect CardAd')

                if len(car_ads) < 1: # Sometimes the search engine just gives us 0 result and not a 404 error
                    break

                print(f'Processing page № {page}.')
                for car in car_ads:
                    raw = car.get('href', '')
                    clean = ''.join(raw.split())
                    car_link = fr"{BASE_URL}{clean}" # Getting the link from car image
                    page_soup = BeautifulSoup(requests.get(car_link, headers=HEADERS).content, 'html.parser')
                    # Finding all relevant data containers
                    params = page_soup.find_all(class_="jsx-cca2db62621d06e0 Item")
                    # Handpicking the price and region because they are in separate containers
                    region = page_soup.find('p',class_="jsx-8a6cb0dff9122af2 SellerSummary__Location").get_text()
                    price = page_soup.find(class_="jsx-d5de33f0fb7287dd Price").get_text()
                    # Dictionary for storing all the data of a current car
                    car_data = {t : '' for t in target_parameters}

                    for i in params:
                        line = i.get_text(separator=' ')
                        for target in target_parameters:
                            if line.startswith(target):
                                car_data[target] = line[len(target):].strip()
                                break

                    car_data['Regione'] = region
                    car_data['Price'] = price
                    car_data['Chilometri'] = car_data['Chilometri'].replace('.', '') # Otherwise it only writes the number till the point
                    car_data['Brand'] = make
                    car_data['Model'] = model


                    if writer is None: # Write the header only on the first time, when `writer` is not announced
                        writer = csv.DictWriter(f, fieldnames=car_data.keys())
                        writer.writeheader()

                    writer.writerow(car_data)

    print("Data parsed into data/raw_data.csv")
