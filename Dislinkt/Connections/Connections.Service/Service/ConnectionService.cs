using Model;
using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
namespace Connections.Service.Service
{
    public class ConnectionService
    {
        
        public ConnectionService(){

        }

        public async Task<IEnumerable<User>> GetUsers()
        {
             var users = await _client.Cypher.Match("(n: User)")
                                                  .Return(n => n.As<User>()).ResultsAsync;
            return Ok(users);
        }
          }
}