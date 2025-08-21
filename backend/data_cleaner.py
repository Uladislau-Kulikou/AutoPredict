import pandas as pd
from re import sub, IGNORECASE
"""
    Data cleaning and preprocessing module for car price modeling.
    - normalize, remove_model_from_version, remove_cv_power: string cleaning utilities for car fields.
    - translation_map, fuel_map, gearbox_map, state_map: mappings from raw scraped values to standardized values.
    - clean_data: main function that loads raw dataset, normalizes fields, handles missing values,
      standardizes categorical variables, cleans numeric fields, and saves a ready-to-use dataset.
"""

CURRENT_YEAR = 2025
pd.set_option('future.no_silent_downcasting', True)


def normalize(s):
    return sub(r'[\s\-_\/]', '', str(s)).lower()


def remove_model_from_version(row):
    """We take normalized model of a car and normalized version.
       If there is a model name in a version, it is removed"""

    model = str(row['Model'])
    version = str(row['Version'])

    model_norm = normalize(model)
    version_norm = normalize(version)

    if version_norm.startswith(model_norm):
        return version[len(model):].strip()
    else:
        return version.strip()


def remove_cv_power(s):
    s = str(s)
    # Removes "120 CV", "120CV", "CV120", "CV 120"
    return sub(r'\b(?:CV\s*\d+|\d+\s*CV)\b', '', s, flags=IGNORECASE).strip()


translation_map = {
    "Tipologia": "Is_new",
    "Brand": "Make",
    "Model": "Model",
    "Versione": "Version",
    "Carburante": "Fuel",
    "Chilometri": "Kilometers",
    "Immatricolazione": "Age",  # we will calculate the age of each car
    "Cambio": "Gearbox",
    "Potenza": "PowerKW",
    "Regione": "Province",
    "Price": "Price"
}

fuel_map = {
    "Benzina": "Gasoline",
    "GPL": "LPG",
    "Diesel": "Diesel",
    "Elettrico": "Electric",
    "Metano": "Methane",
    "Altro": "Other",
    "Ibrida (diesel/elettrica)": "Hybrid (Diesel/Electric)",
    "Ibrida (benzina/elettrica)": "Hybrid (Gasoline/Electric)"
}

gearbox_map = {
    "manuale": "manual",
    "automatico": "automatic",
    "semiautomatico": "semi-automatic"
}

state_map = {
    "Usato": 0,
    "Nuovo": 1,
    "KM 0": 1
}


def clean_data():
    print("Cleaing data...")
    df = pd.read_csv("data/raw_data.csv", encoding='utf-8')
    df = df.rename(columns=translation_map)

    # Removing rented cars
    df = df[df["Is_new"] != "Noleggio"]

    # Renaming fields
    df["Is_new"] = df["Is_new"].replace(state_map)

    df["Fuel"] = df["Fuel"].replace(fuel_map)

    df["Gearbox"] = (
        df["Gearbox"]
        .fillna("")
        .astype(str)
        .str.replace(r'^Cambio\s+', '', regex=True)
        .str.lower()
        .map(gearbox_map)
        .fillna("unknown")
    )

    # New cars don't have mileage parameter, so we put `0`
    df["Kilometers"] = df["Kilometers"].fillna(0).astype(int)

    # Leaving only the year "Gennaio 2021" -> "2021"
    df["Age"] = df["Age"].fillna("").astype(str).str.extract(r'(\d{4})')[0].fillna("0")
    df["Age"] = CURRENT_YEAR - df["Age"].astype(int)

    # Leaving only the kw of power in pure digits "22 kW (29 CV)" -> "22"
    df["PowerKW"] = df["PowerKW"].fillna("").astype(str).str.extract(r'(\d+)\s*kW')[0].fillna(0)
    df['PowerKW'] = df['PowerKW'].mask(df['PowerKW'] == 0, pd.NA)
    for model in df['Model'].unique():
        median_kw = df.loc[(df['Model'] == model) & (df['PowerKW'].notna()), 'PowerKW'].astype(int).median()
        # If there is no info about KW power for a model, remove the model entirely from table
        if pd.isna(median_kw):
            df = df[df['Model'] != model]
            continue
        median_kw = int(median_kw)
        df.loc[(df['Model'] == model) & (df['PowerKW'].isna()), 'PowerKW'] = median_kw

    # Leaving only the data about province "Lombardia (MI)" -> "MI"
    df["Province"] = df["Province"].fillna("").astype(str).str.extract(r'\((\w+)\)')[0].fillna("UNK")

    # Leaving only the price "12.900 €" -> "12900"
    df["Price"] = df["Price"].fillna("").astype(str).str.replace(r'[ €.]', '', regex=True)
    df = df[df['Price'].str.isdigit()]

    df["Version"] = df.apply(remove_model_from_version, axis=1)
    df["Version"] = df["Version"].apply(remove_cv_power)
    # Removing double spaces
    df["Version"] = df["Version"].apply(lambda x: sub(r'\s{2,}', ' ', x.strip()))
    df["Version"] = df["Version"].replace('', '-').str.lower()

    df = df.drop_duplicates()
    df.to_csv("data/clean_data.csv", index=False, encoding="utf-8")
    print("Data cleaned successfully!")
