using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UI.Models;

namespace UI.Controllers
{
    public class ValueController : Controller
    {

        private static string accessToken;
        private static string refreshToken;
     
        private static HttpClient Client = new HttpClient();

        public ValueController(HttpClient client)
        { 
            Client = client;
        }

        public async Task<IActionResult> GetAllValues()
        {
            //envoie de ma requeste a mon api 
            var response = await Client.GetAsync("https://localhost:7299/api/Film");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            
           
            return View(result);
        }
        public async Task<IActionResult> Create(Film film)
        {
            await SetupAuthorizationHeader();
            string modify=JsonConvert.SerializeObject(film);
            var data = new StringContent(modify, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("https://localhost:7299/api/Film",data);

            response.EnsureSuccessStatusCode();

            return View(nameof(Index));
        }
        public async Task<IActionResult> Update(Film film)
        {
            await SetupAuthorizationHeader();
            string modify = JsonConvert.SerializeObject(film);
            var data = new StringContent(modify, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync("https://localhost:7299/api/Film",data); ;

            response.EnsureSuccessStatusCode();

            return View(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await SetupAuthorizationHeader();
            var response = await Client.DeleteAsync("https://localhost:7299/api/Film"+id);
            response.EnsureSuccessStatusCode();

            return View(nameof(Index),"Home");
        }

        private async Task SetupAuthorizationHeader()
        {
            //si mon refresh token est null je dois en demander un nouveau
            if (string.IsNullOrEmpty(refreshToken))
            {
                refreshToken = await HttpContext.GetTokenAsync("refreshtoken");
            }
            //si mon access token est null je dopis en demander un nouveau
            if (string.IsNullOrEmpty(accessToken))
            { 
                accessToken= await HttpContext.GetTokenAsync("refreshtoken");
            }
            if (Client.DefaultRequestHeaders.Authorization == null)
            { 
                Client.DefaultRequestHeaders.Authorization= new System.Net.Http.Headers.AuthenticationHeaderValue ("Bearer",accessToken);
            }
        }
    }
}
