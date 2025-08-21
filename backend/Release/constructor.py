import os
import shutil
import subprocess
import Release.search_data_builder as search_data_builder
import sys

def build_release():
    print("Creating folders")
    path = "Release/App"
    os.makedirs(path, exist_ok=True)

    print("Building search_data.json")
    data_path = path + '/data'
    os.makedirs(data_path, exist_ok=True)
    search_data_builder.build(data_path)

    print("Copying model saves")
    model_path = path + '/model'
    os.makedirs(model_path, exist_ok=True)
    shutil.copy("model/model.cbm", f"{model_path}/model.cbm")

    print("Building .exe")
    __build_exe(path)


def __build_exe(path):
    venv_path = "venv"
    python_bin = os.path.join(venv_path, "Scripts", "python.exe")

    # Create virtual env is it was not found
    if not os.path.exists(venv_path):
        print("Virtual environment not found. Creating one...")
        subprocess.run([sys.executable, "-m", "venv", venv_path], check=True)

        # Installing dependencies
        print("Installing dependencies (catboost, pyinstaller)...")
        subprocess.run([python_bin, "-m", "pip", "install", "--upgrade", "pip"], check=True)
        subprocess.run([python_bin, "-m", "pip", "install", "catboost", "pyinstaller"], check=True)

    try:
        subprocess.run([
            python_bin, "-m", "PyInstaller",
            "--onedir",
            "--noconsole",
            "-y",
            "Release/predict.py"
        ], check=True)
    except subprocess.CalledProcessError as e:
        print(e)
        exit(1)

    print("Removing unnecessary files after compilation")
    shutil.move("dist/predict/predict.exe", f"{path}/predict.exe")

    internal_final_dest = f"{path}/_internal"
    if os.path.exists(internal_final_dest):
        shutil.rmtree(internal_final_dest)
    shutil.move("dist/predict/_internal", internal_final_dest)

    for folder in ["build", "dist", "__pycache__"]:
        if os.path.exists(folder):
            shutil.rmtree(folder, ignore_errors=True)

    spec_file = "predict.spec"
    if os.path.exists(spec_file):
        os.remove(spec_file)
