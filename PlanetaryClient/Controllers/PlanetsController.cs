using Microsoft.AspNetCore.Mvc;
using PlanetaryClient.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;

namespace PlanetaryClient.Controllers;

public class PlanetsController: Controller
{
  public IActionResult Index()
  {
    List<Planet> planets = Planet.GetPlanets();
    return View(planets);
  }

  

  // public IActionResult Index(int page)
  // {
  //   List<Planet> planets = Planet.GetPlanets(page);
  //   return View(planets);
  // }
  // {
  //   List<Planet> planets = Planet.GetPlanets();
  //   return View(planets);
  // }

  public IActionResult Details(int id)
  {
    Planet planet = Planet.GetDetails(id);
    return View(planet);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Planet planet)
  {
    Planet.Post(planet);
    return RedirectToAction("Index");
  }

  public ActionResult Edit(int id)
  {
    Planet planet = Planet.GetDetails(id);
    return View(planet);
  }

  [HttpPost]
  public ActionResult Edit(Planet planet)
  {
    Planet.Put(planet);
    return RedirectToAction("Details", new { id = planet.PlanetId });
  }

  public ActionResult Delete(int id)
  {
    Planet planet = Planet.GetDetails(id);
    return View(planet);
  }

  [HttpGet, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Planet.Delete(id);
    return RedirectToAction("Index");
  }

    [HttpPost, ActionName("Search")]
    public IActionResult Search(string name)
    {
      List<Planet> planets = Planet.GetPlanets();
      List<Planet> result = planets.FindAll(planet => planet.Name.ToLower().Equals(name.ToLower()));
      return View(result);
    }


//pagination help from Brishna below- need to also pass in view bag in separate code
  // public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
  // {
  //   List<Planet> planetList = new List<Planet> { };
  //   using (var httpClient = new HttpClient())
  //   {
  //     using (var response = await httpClient.GetAsync($"https://localhost:5000/api/Planets?question=false&page=%7Bpage%7D&pageSize=%7BpageSize%7D%22"))
  //     {
  //       string apiResponse = await response.Content.ReadAsStringAsync();
  //       JObject jsonResponse = JObject.Parse(apiResponse);
  //       JArray planetArray = (JArray)jsonResponse["data"];
  //       planetList = planetArray.ToObject<List<Planet>>();
  //     }
  //   }
  //   return View(planetList);
  // }
}