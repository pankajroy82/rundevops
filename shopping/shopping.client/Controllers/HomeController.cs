using Microsoft.AspNetCore.Mvc;
using shopping.api.Models;
using shopping.client.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace shopping.client.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger<HomeController> _logger;
        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = httpClientFactory.CreateClient("ShoppingAPIClient");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("/product");
                var content = await response.Content.ReadAsStringAsync();
                var productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
                return View(productList);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return View(s);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
