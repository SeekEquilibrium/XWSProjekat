using Model;
using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
using Connections.Service.Service;

namespace UsersController
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IGraphClient _client;

        private readonly ConnectionService _connectionService;

        public UsersController(IGraphClient client, ConnectionService connectionService)
        {
            _client = client;
            _connectionService = connectionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _connectionService.Get();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var users = await _connectionService.GetById(id);

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _connectionService.Create(user);

            return Ok();
        }

        [HttpGet("{eid}/connect/{did}/")]
        public async Task<IActionResult> ConnectUsers(Guid did, Guid eid)
        {
            await _connectionService.ConnectUsers(did, eid);

            return Ok();
        }

        [HttpGet("/followers/{id}")]
        public async Task<List<User>> GetFollowers(Guid id)
        {
            var query = await _connectionService.GetFollowers(id);

            var relationships = query.ToList();
            return relationships;
        } 

        [HttpGet("/RecommendUsers/{id}")]
        public async Task<List<User>> Getrecommendations(Guid id)
        {
            var query = await _connectionService.GetRecommendations(id);

            var relationships = query.ToList();
            return relationships;
        }


    }
}