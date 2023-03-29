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
}