using ADRES_FROND.Modls;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Reflection;
using Newtonsoft.Json;

namespace ADRES_FROND.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
        JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contenidos()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<int> Authentication(Login User)
        {

            var json = JsonSerializer.Serialize(User);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClient.CreateClient("API");
            var response = await client.PostAsync("/Authentication", data);
            var content = await response.Content.ReadAsStringAsync();
            var respon = JsonConvert.DeserializeObject<int>(content);
            return respon;
        }
    }
}
