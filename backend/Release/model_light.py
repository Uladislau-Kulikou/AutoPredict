from catboost import CatBoostRegressor, Pool
import numpy as np

class CarPriceModelLight:
    def __init__(self, model_path="model/model.cbm"):
        self.model = CatBoostRegressor()
        self.model.load_model(model_path)
        self.cat_features = [1, 2, 3, 4, 7, 9]

    def predict(self, input_data):
        """
        input_data:
        [[0, "ford", "focus", "-", "petrol", 120000, "manual", 10, 74, "MI"]]
        """
        pool = Pool(data=input_data, cat_features=self.cat_features)
        preds_log = self.model.predict(pool)
        return int(np.expm1(preds_log)[0])
