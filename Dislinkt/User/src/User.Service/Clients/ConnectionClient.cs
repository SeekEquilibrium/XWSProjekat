using User.Service.Models;
using Common;
using System.Net.Http;

namespace User.Service.Clients
{
    public class ConnectionClient
    {
        private readonly HttpClient httpClient;

        public ConnectionClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task PostUserAsync(Guid UserId)
        {
            await httpClient.PostAsync($"/users",new StringContent(UserId.ToString()));
                
        }

        /*
            Pogadjamo endpoint od UsersController-a
            Definisemo putanju klijenta u Program.cs
        */
        
    }
}