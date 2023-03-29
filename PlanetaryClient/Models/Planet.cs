using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PlanetaryClient.Models
{
  public class Planet
  {
    public int PlanetId { get; set; }
    public string Name { get; set; }
    public string FunFact { get; set; }
    public string Climate { get; set; }
    public string LifeFormDetails { get; set; }
    public int Population { get; set; }

    public static List<Planet> GetPlanets()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Planet> planetList = JsonConvert.DeserializeObject<List<Planet>>(jsonResponse.ToString());

      return planetList;
    }

    public static Planet GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Planet planet = JsonConvert.DeserializeObject<Planet>(jsonResponse.ToString());

      return planet;
    }

    public static void Post(Planet planet)
    {
      string jsonPlanet = JsonConvert.SerializeObject(planet);
      ApiHelper.Post(jsonPlanet);
    }

    public static void Put(Planet planet)
    {
      string jsonPlanet = JsonConvert.SerializeObject(planet);
      ApiHelper.Put(planet.PlanetId, jsonPlanet);
    }

    public static void Delete (int id)
    {
      ApiHelper.Delete(id);
    }
  }
}