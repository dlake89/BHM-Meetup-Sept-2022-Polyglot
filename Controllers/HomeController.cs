using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BHM_Meetup_Sept_2022_Polyglot.Models;
using System.Text.Json;
using System.Text;
namespace BHM_Meetup_Sept_2022_Polyglot.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientFactory _clientFactory;
    public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _clientFactory = clientFactory;
    }

    public IActionResult Index(MultiplicationValues? values)
    {
        return View(values);
    }

    [HttpPost]
    public async Task<IActionResult> Multiply(MultiplicationValues multiplier)
    {
        HttpClient? httpClient = _clientFactory.CreateClient();

        using var response = await httpClient.PostAsync("http://go-multiplication:8080/multiply",
         new StringContent(JsonSerializer.Serialize(multiplier), Encoding.UTF8, "application/json"));

        using var contentStream = await response.Content.ReadAsStreamAsync();

        var multiplicationAnswer = await JsonSerializer.DeserializeAsync<MultiplicationValues>(contentStream);

        return View("Index", multiplicationAnswer);
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

public class MultiplicationValues
{
    public float a { get; set; }
    public float b { get; set; }
    public float answer { get; set; }
}
