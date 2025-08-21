import sys
import json
from model_light import CarPriceModelLight

"""
    Python script for predicting car prices from JSON input.
    - This file is intended to be compiled into an executable and called from a C# interface.
    - It reads car data as JSON from stdin, converts it to a pandas DataFrame,
      loads the trained CarPriceModel, makes a prediction, and prints the estimated price to stdout.
    - All logging/debug messages should go to stderr to avoid interfering with the data exchange with C#.
"""

def predict_from_json():
    input_str = sys.stdin.read()
    car_data = json.loads(input_str)

    features = [
        int(car_data["Is_new"]),
        car_data["Make"],
        car_data["Model"],
        car_data["Version"],
        car_data["Fuel"],
        int(car_data["Kilometers"]),
        int(car_data["Age"]),
        car_data["Gearbox"],
        int(car_data["PowerKW"]),
        car_data["Province"]
    ]

    model = CarPriceModelLight()
    pred = model.predict([features])

    print(f'Estimated price is \n{pred:,.0f} €'.replace(',', ' '))


if __name__ == "__main__":
    predict_from_json()
