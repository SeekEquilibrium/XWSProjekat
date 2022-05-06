using User.Service.Models;
using Common;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using User.Service.DTO;



namespace User.Service.Clients
{
    public class ConnectionClient
    {
        private readonly HttpClient httpClient;

        public ConnectionClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task PostUserAsync(Guid id)
        {
            ClientDTO user = new ClientDTO(id);

            await httpClient.PostAsJsonAsync<ClientDTO>($"/Users", user);
                
        }

        public async Task ConnectAsync(Guid sender, Guid reciever)
        {

            object value = await httpClient.GetAsync($"/Users/{sender}/connect/{reciever}");
            
        }


        
    }
}