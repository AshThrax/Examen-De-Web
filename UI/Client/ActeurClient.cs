using MediatR;
using Newtonsoft.Json;
using UI.Models;

namespace UI.Client
{
    public interface IActeurClient
    {
        Task<IEnumerable<ActeurViewModel>> GetallAsync();
        Task<ActeurViewModel> GetAsync(int id);
        Task<Unit> PostAsync(ActeurViewModel model);
        Task<Unit> PutAsync(ActeurViewModel model, int id);
        Task<Unit> DeleteAsync(int id);

    }
    public class ActeurClient : IActeurClient
    {
        private readonly HttpClient Client;

        public ActeurClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7299/api");
            Client = client;
        }

        public async Task<Unit> DeleteAsync(int id)
        {
            string url = "Film/delete" + id;
            await Client.DeleteAsync(url);
            return Unit.Value;
        }

        public async Task<IEnumerable<ActeurViewModel>> GetallAsync()
        {
            IEnumerable<ActeurViewModel> movies;

            string url = "Film/get";
            var Response = await Client.GetAsync(url);
            if (!Response.IsSuccessStatusCode)
            {
                throw new Exception("cannot retrieve Data");
            }
            var content = await Response.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<IEnumerable<ActeurViewModel>>(content);

            return task;
        }
        public async Task<ActeurViewModel> GetAsync(int id)
        {
            string url = "Film/get";
            var Response = await Client.GetAsync(url);
            if (!Response.IsSuccessStatusCode)
            {
                throw new Exception("cannot retrieve Data");
            }
            var content = await Response.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<ActeurViewModel>(content);
            return task;
        }

        public async Task<Unit> PostAsync(ActeurViewModel model)
        {
            string url = "Film/get";
            var json = JsonConvert.SerializeObject(model);
            var httpResponse = await Client.PostAsJsonAsync(url, json);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("cannot add the data you asked");
            }
            var PostTask = JsonConvert.DeserializeObject<ActeurViewModel>(await httpResponse.Content.ReadAsStringAsync());
            return Unit.Value;
        }

        public async Task<Unit> PutAsync(ActeurViewModel model, int id)
        {
            string url = "Film/put" + id;
            var json = JsonConvert.SerializeObject(model);
            var httpResponse = await Client.PutAsJsonAsync(url, json);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("cannot add the data you asked");
            }
            
            return Unit.Value;

        }
    }
}
