using Post.Service.DTO;

namespace Post.Service.Clients
{
    public class UserClient
    {
        private readonly HttpClient httpClient;

        public UserClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /*
            Pogadjamo endpoint od UsersController-a
            Definisemo putanju klijenta u Program.cs
        */
        public async Task<UserDTO> GetUserAsync(Guid UserId)
        {
            var user = await httpClient.GetFromJsonAsync<UserDTO>($"/users/{UserId}");
            return user;
        }
        public async Task<Guid> GetUserId()
        {
            var id = await httpClient.GetFromJsonAsync<Guid>($"/users/getId");
            return id;
        }
    }
}