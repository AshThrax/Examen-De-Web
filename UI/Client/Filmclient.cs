using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UI.Models;

namespace UI.Client
{
    public interface IFilmClient
    {
        Task<IList<FilmViewModel>> GetallAsync();
        Task<FilmViewModel> GetAsync(int id);
        Task<FilmViewModel> PostAsync (FilmViewModel model);
        Task<FilmViewModel> PutAsync (FilmViewModel model, int id);
        void DeleteAsync (int id);

    }
    public class Filmclient :  IFilmClient
    {
        private readonly HttpClient Client;
        private const string address = "https://localhost:7299/api/Film/";
        public Filmclient(HttpClient client)
        {
           
            Client = client;
        }

        public async void DeleteAsync(int id)
        {
            var url = id;
            await Client.DeleteAsync($"{id}");
           
        }

        public async Task<IList<FilmViewModel>> GetallAsync()
        {
            

            string url = "get";
            var Response = await Client.GetAsync(address);
            if (!Response.IsSuccessStatusCode)
            {
                throw new Exception("cannot retrieve Data");
            }
            var content =await Response.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<IList<FilmViewModel>>(content);

            return task;
        }
        public async Task<FilmViewModel> GetAsync(int id)
        {
            string url = "Film/get";
            var Response = await Client.GetAsync($"{address}{id}");
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
                var httpResponse =await Client.PostAsJsonAsync(address, json);
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
                var httpResponse =await Client.PutAsJsonAsync($"{address}{id}", json);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("cannot add the data you asked");
                }
                var PutTask =JsonConvert.DeserializeObject<FilmViewModel>(await httpResponse.Content.ReadAsStringAsync());
                return PutTask;

        }
    }
}
