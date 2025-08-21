import pandas as pd
import json

"Builds the json file for the C# application, so you can choose them in comboboxes"

def build(build_path):
    df = pd.read_csv("data/clean_data.csv")

    df = df[["Make", "Model", "Version", "Fuel", "Province"]]
    df = df.drop_duplicates().apply(lambda col: col.str.strip() if col.dtype == "object" else col)

    data = {}
    for make, make_df in df.groupby("Make"):
        models_dict = {}
        for model, model_df in make_df.groupby("Model"):
            versions = sorted(model_df["Version"].dropna().unique().tolist())
            if "-" not in versions:
                versions.insert(0, "-")
            else:
                versions = ["-"] + [v for v in versions if v != "-"]
            models_dict[model] = versions
        data[make] = models_dict

    fuel_types = sorted(df["Fuel"].dropna().unique().tolist())
    provinces = sorted(df["Province"].dropna().unique().tolist())

    result = {
        "cars": data,
        "fuel_types": fuel_types,
        "provinces": provinces
    }

    with open(f"{build_path}/search_data.json", "w", encoding="utf-8") as f:
        json.dump(result, f, ensure_ascii=False, indent=4)

    print(f"JSON saved to {build_path}/search_data.json")
