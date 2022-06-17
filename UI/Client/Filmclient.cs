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
            IEnumerable<FilmViewModel> movies;

            string url = "Film/get";
            var Response = await Client.GetAsync(url);
            if (!Response.IsSuccessStatusCode)
            {
                throw new Exception("cannot retrieve Data");
            }
            var content =await Response.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<IEnumerable<FilmViewModel>>(content);

            return task;
        }
        public async Task<FilmViewModel> GetAsync(int id)
        {
            string url = "Film/get";
            var Response = await Client.GetAsync(url);
            if (!Response.IsSuccessStatusCode)
            {
                throw new Exception("cannot retrieve Data");
            }
            var content = await Response.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<FilmViewModel>(content);
            return task;
        }

        public async Task<FilmViewModel> PostAsync(FilmViewModel model)
        {
                string url = "Film/get";
                var json = JsonConvert.SerializeObject(model);
                var httpResponse =await Client.PostAsJsonAsync(url, json);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("cannot add the data you asked");
                }
                var PostTask = JsonConvert.DeserializeObject<FilmViewModel>(await httpResponse.Content.ReadAsStringAsync());
                return PostTask;
        }

        public async Task<FilmViewModel>  PutAsync(FilmViewModel model, int id)
        {
                string url = "Film/put"+id;
                var json =JsonConvert.SerializeObject(model);
                var httpResponse =await Client.PutAsJsonAsync(url, json);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("cannot add the data you asked");
                }
                var PutTask =JsonConvert.DeserializeObject<FilmViewModel>(await httpResponse.Content.ReadAsStringAsync());
                return PutTask;

        }
    }
}
