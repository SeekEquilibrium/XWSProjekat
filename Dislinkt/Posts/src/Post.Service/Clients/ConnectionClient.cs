using Post.Service.DTO;

namespace Post.Service.Clients
{
    public class ConnectionClient
    {

        private readonly HttpClient httpClient;

        public ConnectionClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ConnectionDTO>> GetConnectedAsync(Guid userId){
            var users = await httpClient.GetFromJsonAsync<IEnumerable<ConnectionDTO>>($"/followers/{userId}");
            return users;
        }
    }
}