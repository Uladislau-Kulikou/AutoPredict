import requests
import json
from pathlib import Path
"""
    This module is responsible for fetching the list of all cars from the website's internal API.
    It simulates the same HTTP requests that the website itself makes when loading data.
    The script sends the request, retrieves the JSON response, and parses it into a usable format
    In other words, it replicates the site's internal data loading mechanism to collect the complete car database.
"""

BASE_URL = "https://www.automobile.it"
HEADERS = {
    "User-Agent": (
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:140.0) "
        "Gecko/20100101 Firefox/140.0"
    ),
    "Accept": "application/json",
    "X-Requested-With": "XMLHttpRequest"
}

session = requests.Session()
session.headers.update(HEADERS)

def get_makes() -> dict[str, str]:
    url = f"{BASE_URL}/api/v1/makes"
    r = session.get(url)
    r.raise_for_status()
    data = r.json()
    items = data.get("all", [])
    makes = {}

    for item in items:
        mid = str(item.get("id", "")).strip()
        name = item.get("slugLabel", "").strip()
        if mid and name != "Altre Marche":
            makes[mid] = name
    return makes


def get_models(make_id: str) -> dict[str, str]:
    url = f"{BASE_URL}/api/v1/makes/{make_id}/models"
    r = session.get(url)
    r.raise_for_status()
    data = r.json()
    items = data.get("models", [])
    models = {}

    for item in items:
        mid = str(item.get("slugLabel", "")).strip()
        name = item.get("label", "").strip()
        if mid and name != "Altri Modelli":
            models[mid] = name
    return models


def build_brands_models_json(path: Path):
    result: dict[str, dict[str, str]] = {}
    makes = get_makes()
    for make_id, make_name in makes.items():
        models = get_models(make_id)
        if models:
            result[make_name] = models
        else:
            result[make_name] = {}

    with path.open("w", encoding="utf-8") as f:
        json.dump(result, f, ensure_ascii=False, indent=2)


def build_car_models_json():
    out_path = Path("data/make_models.json")
    build_brands_models_json(out_path)
    print(f"Saved makes and models to: {out_path.resolve()}")
