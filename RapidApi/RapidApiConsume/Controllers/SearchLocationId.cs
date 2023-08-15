using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationId : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                List<BookingApiLocationSearchModel> model = new List<BookingApiLocationSearchModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://apidojo-booking-v1.p.rapidapi.com/locations/auto-complete?text={cityName}&languagecode=en-us"),
                    Headers =
    {
        { "X-RapidAPI-Key", "b09a6e15acmshef3f3f5a70507f8p19b3efjsn6106bc89dc9a" },
        { "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchModel>>(body);
                    return View(model.Take(1).ToList());
                }
            }
            else
            {
                List<BookingApiLocationSearchModel> model = new List<BookingApiLocationSearchModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://apidojo-booking-v1.p.rapidapi.com/locations/auto-complete?text=paris&languagecode=en-us"),
                    Headers =
    {
        { "X-RapidAPI-Key", "b09a6e15acmshef3f3f5a70507f8p19b3efjsn6106bc89dc9a" },
        { "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchModel>>(body);
                    return View(model.Take(1).ToList());
                }
            }
           
        }
    }
}
