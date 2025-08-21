import parser
import json_builder
import data_cleaner
import Release.constructor as constructor

from model import CarPriceModel

"""
    Script for preparing and training the car price model.
    - main(prepare_data=False, clean=True, train_model=False, build_release=False): orchestrates the full pipeline:
      1) builds JSON of car models,
      2) scrapes and parses raw data,
      3) cleans the dataset,
      4) trains and saves the model if requested.
      5) Compliles the app (note that C# interface .exe iss till needed)
    - This script is intended for development/training purposes only and is not used in the release version.
"""

def main(prepare_data=False, clean=True, train_model=False, build_release=False):
    # Attention. Data parser will only add rows to the .csv file with current settings.
    if prepare_data:
        json_builder.build_car_models_json()
        parser.parse_data()  # Be carefull. It takes about 24 hours to complete

    if clean:
        data_cleaner.clean_data()

    if train_model:
        model = CarPriceModel()
        model.train()
        model.save()

    if build_release:
        constructor.build_release()


if __name__ == "__main__":
    main(prepare_data=False, clean =True, train_model=False, build_release=True)
