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
//neeewwwwwbbbbbsssssssss
  //Best guess for now on search function
    public static async Task<string> Get(string dropdownvalue, string input)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      // RestRequest request = new RestRequest($"api/planets/{id}", Method.Get); // Do we need to pass the Method.Search here like we did with Method.Delete or would it be Method.Get?
      RestRequest request = new RestRequest($"api/planets?{dropdownvalue}={input}");
      
        // .AddParamter("name");

      // RestResponse response = await client.GetAsync<SearchResponse>(request);

      //These are from the earlier Get and GetAll      
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
  }
}

//on form side populate dropdown, each dropdowns value = the search type