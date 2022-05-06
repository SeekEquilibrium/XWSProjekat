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

        public async Task<IEnumerable<Guid>> GetConnectedAsync(Guid userId){     //TO DO: napraviti DTO
            var users = await httpClient.GetFromJsonAsync<IEnumerable<Guid>>($"/Users/followers/{userId}");   //proveriti endpoint
            return users;
        }
    }
}