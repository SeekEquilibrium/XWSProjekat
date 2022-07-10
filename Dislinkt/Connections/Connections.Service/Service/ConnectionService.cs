using Model;
using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
namespace Connections.Service.Service
{
    public class ConnectionService
    {
        private readonly IGraphClient _client;

        public ConnectionService(IGraphClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<User>> Get()
        {
             var users = await _client.Cypher.Match("(n: User)")
                                                  .Return(n => n.As<User>()).ResultsAsync;
            return users;
        }

        public async Task<User> GetById(Guid id)
        {
            var users = await _client.Cypher.Match("(d:User)")
                                                  .Where((User d) => d.id == id)
                                                  .Return(d => d.As<User>()).ResultsAsync;

            return users.LastOrDefault();
        }

        public async Task Create(User user)
        {
            await _client.Cypher.Create("(d:User $user)")
                                .WithParam("user", user)
                                .ExecuteWithoutResultsAsync();

        }

        public async Task ConnectUsers(Guid did, Guid eid)
        {
            await _client.Cypher.Match("(d:User), (e:User)")
                                .Where((User d, User e) => d.id == did && e.id == eid)
                                .Create("(d)-[r:follows]->(e)")
                                .ExecuteWithoutResultsAsync();

            await _client.Cypher.Match("(d:User), (e:User)")
                                .Where((User d, User e) => d.id == did && e.id == eid)
                                .Create("(e)-[r:follows]->(d)")
                                .ExecuteWithoutResultsAsync();

        }

        public async Task<List<User>> GetFollowers(Guid id)
        {
            var query = await _client.Cypher.Match("(u1:User)-[:follows]->(u2:User)")
                                                  .Where((User u1) => u1.id == id)
                                                  .Return(u2 => u2.As<User>()).ResultsAsync;

            var relationships = query.ToList();
            return relationships;
        }
        public async Task<List<User>> GetRecommendations(Guid id)
        {
            var query = await _client.Cypher.Match("(u1:User)-[:follows]->(u2:User)<-[:follows]-(u3:User)")
                                                  .Where((User u1) => u1.id == id)
                                                  .Return(u3 => u3.As<User>()).ResultsAsync;

            var relationships = query.ToList();
            return relationships;
        }

    }
}