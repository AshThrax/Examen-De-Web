using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class ValueController : Controller
    {

        private static string accessToken;
        private static string refreshToken;
        private static HttpClient Client = new HttpClient();

        public async Task<IActionResult> GetAllValues()
        {
            var response = await Client.GetAsync("http://localhost:13826/api/values");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            await SetupAuthorizationHeader();

            var response = await Client.PostAsync(
                "http://localhost:13826/api/values",
                 new StringContent(JsonConvert.SerializeObject(GetSamplePayload()),
                 Encoding.UTF8,
                 "application/json")
            );

            response.EnsureSuccessStatusCode();

            return View(nameof(Index));
        }
        public async Task<IActionResult> Update()
        {
            await SetupAuthorizationHeader();
            var response = await Client.PutAsync(
                "http://localhost:13826/api/values",
                new StringContent(JsonConvert.SerializeObject(GetSamplePayload()),
                Encoding.UTF8,
                "application/json"));

            response.EnsureSuccessStatusCode();

            return View(nameof(Index));
        }

        public async Task<IActionResult> Delete()
        {
            await SetupAuthorizationHeader();
            var response = await Client.DeleteAsync("http://localhost:13826/api/values/1");
            response.EnsureSuccessStatusCode();

            return View(nameof(Index));
        }

    }
}
