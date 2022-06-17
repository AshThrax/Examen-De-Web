using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UI.Models;

namespace UI.Client
{
    public interface IFilmClient
    {
        Task<IEnumerable<FilmViewModel>> GetallAsync();
        Task<FilmViewModel> GetAsync(int id);
        void PostAsync (FilmViewModel model);
        void PutAsync (FilmViewModel model, int id);
        void DeleteAsync (int id);

    }
    public class Filmclient : IFilmClient
    {
        private readonly HttpClient Client;

        public Filmclient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7299/api");
            Client = client;
        }

        public async void DeleteAsync(int id)
        {
            string url = "Film/delete"+id;
            await Client.DeleteAsync(url);
           
        }

        public async Task<IEnumerable<FilmViewModel>> GetallAsync()
        {
            string url = "Film/Get";
            var result = await Client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<IEnumerable<FilmViewModel>>(result);
        }
        public async Task<FilmViewModel> GetAsync(int id)
        {
                string url = "Film/Get"+id;
                var result = await Client.GetStringAsync(url);
                FilmViewModel model = JsonConvert.DeserializeObject<FilmViewModel>(result);
                return model;
        }

        public async void PostAsync(FilmViewModel model)
        {
                string url = "Film/Get";
                string json = JsonConvert.SerializeObject(model);
                await Client.PostAsJsonAsync(url, json);
        }

        public async void  PutAsync(FilmViewModel model, int id)
        {
                string url = "Film/put"+id;
                string json =JsonConvert.SerializeObject(model);
                await Client.PutAsJsonAsync(url, json);
                
        }
    }
}
