using Microsoft.AspNetCore.Mvc;
using PlanetaryClient.Models;

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

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Planet.Delete(id);
    return RedirectToAction("Index");
  }
}