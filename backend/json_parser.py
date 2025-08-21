import json
from pathlib import Path
"""
    Utility functions for reading JSON files and iterating over car make/model data.
    - read_json_file: safely loads JSON content from a given file path, handling errors gracefully.
    - car_iter: generator that yields (brand, model) pairs from the makes_models.json dataset.
"""

def read_json_file(path: Path) -> dict:
    try:
        with path.open("r", encoding="utf-8") as f:
            data = json.load(f)
        return data
    except FileNotFoundError:
        print(f"File not found: {path}")
        return {}
    except json.JSONDecodeError as e:
        print(f"JSON Decoding error in {path}: {e}")
        return {}

def car_iter() -> tuple[str, str, str]:
    file_path = Path("data/makes_models.json")
    content = read_json_file(file_path)
    if not content:
        return
    for brand, models_dict in content.items():
        for model in models_dict.keys():
           yield brand, model
