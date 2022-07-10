using Model;
using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
using Connections.Service.protos.ConnectionProto;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
namespace Connections.Service.Service
{
    public class ConnectionService : ConnectionProtoService.ConnectionProtoServiceBase
    {
        private readonly IGraphClient _client;

        public ConnectionService(IGraphClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<User>> Get(Empty _,  ServerCallContext context)
        {
             var users = await _client.Cypher.Match("(n: User)")
                                                  .Return(n => n.As<User>()).ResultsAsync;
            return users;
        }

        public async Task<User> GetById(GetRequest request,ServerCallContext context)
        {
            var users = await _client.Cypher.Match("(d:User)")
                                                  .Where((User d) => d.id.ToString().Equals (request.Value))
                                                  .Return(d => d.As<User>()).ResultsAsync;

            return users.LastOrDefault();
        }

        public async Task Create(ConnectionModel model)
        {
            await _client.Cypher.Create("(d:User $user)")
                                .WithParam("user", model.Value)
                                .ExecuteWithoutResultsAsync();

        }

        public async Task ConnectUsers(TwoUsersModel model , ServerCallContext context)
        {
            await _client.Cypher.Match("(d:User), (e:User)")
                                .Where((User d, User e) => d.id.ToString().Equals (model.Value) && e.id.ToString().Equals(model.Value2))
                                .Create("(d)-[r:follows]->(e)")
                                .ExecuteWithoutResultsAsync();

            await _client.Cypher.Match("(d:User), (e:User)")
                                .Where((User d, User e) => d.id.ToString().Equals(model.Value) && e.id.ToString().Equals(model.Value2))
                                .Create("(e)-[r:follows]->(d)")
                                .ExecuteWithoutResultsAsync();

        }

        public async Task<List<User>> GetFollowers(GetRequest request , ServerCallContext context)
        {
            var query = await _client.Cypher.Match("(u1:User)-[:follows]->(u2:User)")
                                                  .Where((User u1) => u1.id.ToString().Equals(request.Value))
                                                  .Return(u2 => u2.As<User>()).ResultsAsync;

            var relationships = query.ToList();
            return relationships;
        }
        public async Task<List<User>> GetRecommendations(GetRequest request , ServerCallContext context)
        {
            var query = await _client.Cypher.Match("(u1:User)-[:follows]->(u2:User)<-[:follows]-(u3:User)")
                                                  .Where((User u1) => u1.id.ToString().Equals( request.Value))
                                                  .Return(u3 => u3.As<User>()).ResultsAsync;

            var relationships = query.ToList();
            return relationships;
        }

    }
}