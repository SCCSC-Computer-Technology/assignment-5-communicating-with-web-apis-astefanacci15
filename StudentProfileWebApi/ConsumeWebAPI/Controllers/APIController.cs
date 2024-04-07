using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeWebAPI.Controllers
{
    public class APIController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44361/api");
        private readonly HttpClient _httpClient;
        public APIController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ClassModel> classes = new List<ClassModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress).Result;

            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                classes = JsonConvert.DeserializeObject<List<ClassModel>>(data);
            }
            return View(classes);
        }
    }
}
