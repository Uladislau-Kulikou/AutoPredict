using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

class SearchData
{
    JObject data;

    public SearchData(string path)
    {
        string json = File.ReadAllText(path);
        data = JObject.Parse(json);
    }

    public List<string> GetMakes()
    {
        var makes = new List<string>();
        var cars = (JObject)data["cars"];
        foreach (var make in cars.Properties())
            makes.Add(make.Name);
        return makes;
    }

    public List<string> GetModels(string make)
    {
        var models = new List<string>();
        var cars = (JObject)data["cars"];
        if (cars[make] is JObject makeObj)
        {
            foreach (var model in makeObj.Properties())
                models.Add(model.Name);
        }
        return models;
    }

    public List<string> GetVersions(string make, string model)
    {
        var versions = new List<string>();
        var cars = (JObject)data["cars"];
        if (cars[make] is JObject makeObj && makeObj[model] is JArray versionArray)
        {
            foreach (var v in versionArray)
                versions.Add(v.ToString());
        }
        return versions;
    }

    public List<string> GetProvinces()
    {
        List<string> provinces = data["provinces"].ToObject<List<string>>();
        return provinces;

    }

    public List<string> GetFuelTypes()
    {
        List<string> fuelTypes = data["fuel_types"].ToObject<List<string>>();
        return fuelTypes;
    }
}
