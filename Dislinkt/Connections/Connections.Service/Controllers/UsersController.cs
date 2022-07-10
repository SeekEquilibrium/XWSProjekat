using Model;
using Microsoft.AspNetCore.Mvc;
using Neo4jClient;


namespace UsersController
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IGraphClient _client;

        public UsersController(IGraphClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _client.Cypher.Match("(n: User)")
                                                  .Return(n => n.As<User>()).ResultsAsync;

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var users = await _client.Cypher.Match("(d:User)")
                                                  .Where((User d) => d.id == id)
                                                  .Return(d => d.As<User>()).ResultsAsync;

            return Ok(users.LastOrDefault());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _client.Cypher.Create("(d:User $user)")
                                .WithParam("user", user)
                                .ExecuteWithoutResultsAsync();

            return Ok();
        }

        [HttpGet("{eid}/connect/{did}/")]
        public async Task<IActionResult> ConnectUsers(Guid did, Guid eid)
        {
            await _client.Cypher.Match("(d:User), (e:User)")
                                .Where((User d, User e) => d.id == did && e.id == eid)
                                .Create("(d)-[r:follows]->(e)")
                                .ExecuteWithoutResultsAsync();

            await _client.Cypher.Match("(d:User), (e:User)")
                                .Where((User d, User e) => d.id == did && e.id == eid)
                                .Create("(e)-[r:follows]->(d)")
                                .ExecuteWithoutResultsAsync();

            
            return Ok();
        }

        [HttpGet("/followers/{id}")]
        public async Task<List<User>> GetFollowers(Guid id)
        {
            var query = await _client.Cypher.Match("(u1:User)-[:follows]->(u2:User)")
                                                  .Where((User u1) => u1.id == id)
                                                  .Return(u2 => u2.As<User>()).ResultsAsync;

            var relationships = query.ToList();
            return relationships;
        } 

        [HttpGet("/RecommendUsers/{id}")]
        public async Task<List<User>> Getrecommendations(Guid id)
        {
            var query = await _client.Cypher.Match("(u1:User)-[:follows]->(u2:User)<-[:follows]-(u3:User)")
                                                  .Where((User u1) => u1.id == id)
                                                  .Return(u3 => u3.As<User>()).ResultsAsync;

            var relationships = query.ToList();
            return relationships;
        }


    }
}