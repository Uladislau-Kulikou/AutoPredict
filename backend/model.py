import os
os.environ["TF_ENABLE_ONEDNN_OPTS"] = "0"

import pandas as pd
from catboost import CatBoostRegressor, Pool
from sklearn.model_selection import train_test_split
import numpy as np
import matplotlib.pyplot as plt


"""
    This script is intended for development/training purposes only and is not used in the release version.
    It is too heavy to be used in release. car_model_light.py is used in release instead
"""

class CarPriceModel:
    def __init__(self, model_path="model/model.cbm"):
        self.model = None
        self.model_path = model_path
        self.cat_features = []

    def train(self, csv_path="data/clean_data.csv"):
        y, X = self.build_dataset(csv_path)
        y = np.log1p(y)
        X_train, X_val, y_train, y_val = train_test_split(X, y, test_size=0.05, random_state=42)
        self.cat_features = ['Make', 'Model', 'Version', 'Fuel', 'Gearbox', 'Province']

        median_price = y_train.median()
        weights = 1 + np.abs(y_train - median_price) / median_price

        train_pool = Pool(data=X_train, label=y_train, cat_features=self.cat_features, weight=weights)
        val_pool = Pool(data=X_val, label=y_val, cat_features=self.cat_features)

        self.model = CatBoostRegressor(
            iterations=2000,
            loss_function="RMSE",
            eval_metric="SMAPE",
            early_stopping_rounds=50,
            learning_rate=0.1,
            use_best_model=True,
            depth=8,
            verbose=100,
            random_seed=42
        )

        self.model.fit(train_pool, eval_set=val_pool)

    @staticmethod
    def build_dataset(csv_path="data/clean_data.csv"):
        df = pd.read_csv(csv_path).dropna()
        y = df["Price"]
        X = df.drop(columns=["Price"])
        return y, X


    def save(self):
        os.makedirs(os.path.dirname(self.model_path), exist_ok=True)
        self.model.save_model(self.model_path)
        print(f"Model saved to {self.model_path}")


    def load(self):
        self.model = CatBoostRegressor()
        self.model.load_model(self.model_path)


    def predict(self, input_data: pd.DataFrame):
        for col in self.cat_features:
            if col in input_data.columns and input_data[col].dtype == object:
                input_data[col] = input_data[col].str.lower()
        preds_log = self.model.predict(input_data)
        return np.expm1(preds_log)

    def regression_error_report(self, percentiles=[50, 95], thresholds=[5, 10]):
        y, X = self.build_dataset()
        y = np.log1p(y)
        X_train, X_val, y_train, y_val = train_test_split(X, y, test_size=0.05, random_state=42)
        y_pred = self.model.predict(X_val)
        errors_percent = np.abs(y_val - y_pred) / y_val * 100

        print("=== Regression Error Report ===")
        for q in percentiles:
            q_val = np.percentile(errors_percent, q)
            print(f"{q}th percentile error: {q_val:.2f}%")

        median_error = np.median(errors_percent)
        mean_error = np.mean(errors_percent)
        print(f"Median error: {median_error:.2f}%")
        print(f"Mean error: {mean_error:.2f}%")

        for t in thresholds:
            pct = (errors_percent <= t).sum() / len(errors_percent) * 100
            print(f"Percentage of cars with error <= {t}%: {pct:.2f}%")

        # Гистограмма распределения ошибок
        plt.figure(figsize=(8, 5))
        plt.hist(errors_percent, bins=100, color='skyblue', edgecolor='black')
        plt.xlabel("Percentage error")
        plt.ylabel("Number of cars")
        plt.title("Distribution of prediction errors (%)")
        plt.show()

        return errors_percent


