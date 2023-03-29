using System.Threading.Tasks;
using RestSharp;

namespace PlanetaryClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/planets", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/planets/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newPlanet)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/planets", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPlanet);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string newPlanet)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/planets/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPlanet);
      await client.PutAsync(request);
    }

    public static async void Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/planets/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }

  //Best guess for now on search function
    public static async Task<string> Search(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/planets?={id}", Method.Get);
      // we need to somehow search by a property (right now name) and then connect to the PlanetId

      //These are from the earlier Get and GetAll      
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
  }
}

//on form side populate dropdown, each dropdowns value = the search type