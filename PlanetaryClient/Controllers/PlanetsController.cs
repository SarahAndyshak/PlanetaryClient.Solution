using Microsoft.AspNetCore.Mvc;
using PlanetaryClient.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using X.PagedList.Mvc;
using X.PagedList;

namespace PlanetaryClient.Controllers;

public class PlanetsController: Controller
{
  //original shows 
  // public IActionResult Index()
  // {
  //   List<Planet> planets = Planet.GetPlanets();
  //   return View(planets);
  // }

  public IActionResult Index(int? page)
  {   
    List<Planet> planets = Planet.GetPlanets();
    int pageSize = 2;
    int pageNumber = (page ?? 1);
    ViewBag.pageNumber = pageNumber;
    return View(planets.ToPagedList(pageNumber, pageSize));
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

    [HttpPost, ActionName("Search")]
    public IActionResult Search(string name)
    {
      List<Planet> planets = Planet.GetPlanets();
      List<Planet> result = planets.FindAll(planet => planet.Name.ToLower().Equals(name.ToLower()));
      return View(result);
    }
}