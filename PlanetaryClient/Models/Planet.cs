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
  }
}