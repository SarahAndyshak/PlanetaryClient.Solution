using Microsoft.AspNetCore.Mvc;
using PlanetaryClient.Models;
using System.Collections.Generic;
using System;

namespace PlanetaryClient.Controllers;

public class PlanetsController: Controller
{
  public IActionResult Index()
  {
    List<Planet> planets = Planet.GetPlanets();
    return View(planets);
  }

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

  // adding in possible search functions:
  // public ActionResult Search(int id)
  // {
  //   Planet planet = Planet.GetDetails(id);
  //   return View(planet);
  // }

  // [HttpPost, ActionName("Details")]
  //   public ActionResult Search(Planet planet)
  // {
  //   Planet.Post(planet);
  //   // Planet planet = Planet.GetDetails(id);
  //   return RedirectToAction("Details", new { id = planet.PlanetId });
  // }

// From Ashe's project/ another example to look at/ Do we need to return a list instead?
    // [HttpGet]
    // public ActionResult ShowSearch()
    // {
    //   return View();
    // }

    // [HttpPost]
    // public ActionResult ShowSearch(string searchName)
    // {
    //   List<Client> model = _db.Clients.Where(p => p.Name.ToLower());
    //   return View("Index", model);
    // }


    [HttpPost, ActionName("Search")]
    public IActionResult Search(string name)
    {
      List<Planet> planets = Planet.GetPlanets();
      List<Planet> result = planets.FindAll(p => p.Name.ToLower().Equals(name.ToLower()));
      //List<Planet> model = planets.Where(p => p.Name.ToLower()); 
      // what replaces PlanetId? MVC doesn't access database
      return View(result);
    }

    //pagination help from Brishna below- need to also pass in view bag in separate code

  //   public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
  // {
  //   List<Planet> planetList = new List<Planet> { };
  //   using (var httpClient = new HttpClient())
  //   {
  //     using (var response = await httpClient.GetAsync($"https://localhost:5001/api/Planets?question=false&page=%7Bpage%7D&pageSize=%7BpageSize%7D%22))
  //     {
  //       string apiResponse = await response.Content.ReadAsStringAsync();
  //       JObject jsonResponse = JObject.Parse(apiResponse);
  //       JArray quoteArray = (JArray)jsonResponse["data"];
  //       quoteList = quoteArray.ToObject<List<Planet>>();
  //     }
  //   }
}