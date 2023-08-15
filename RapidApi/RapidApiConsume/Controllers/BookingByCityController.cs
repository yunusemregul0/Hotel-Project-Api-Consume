using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class BookingByCityController : Controller
    {
        public async Task<IActionResult> Index(string cityID)
        {
            if (!string.IsNullOrEmpty(cityID))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://apidojo-booking-v1.p.rapidapi.com/properties/list?offset=0&arrival_date=2023-08-15&departure_date=2023-08-23&guest_qty=1&dest_ids={cityID}&room_qty=1&search_type=city&children_age=0&search_id=none&price_filter_currencycode=USD&order_by=popularity&languagecode=en-us&travel_purpose=leisure"),
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
                    var values = JsonConvert.DeserializeObject<BookingApiWebModel>(body);
                    return View(values.result.ToList());
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://apidojo-booking-v1.p.rapidapi.com/properties/list?offset=0&arrival_date=2023-08-15&departure_date=2023-08-23&guest_qty=1&dest_ids=-3712125&room_qty=1&search_type=city&children_age=0&search_id=none&price_filter_currencycode=USD&order_by=popularity&languagecode=en-us&travel_purpose=leisure"),
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
                    var values = JsonConvert.DeserializeObject<BookingApiWebModel>(body);
                    return View(values.result.ToList());
                }
            }
        }
    }
}
