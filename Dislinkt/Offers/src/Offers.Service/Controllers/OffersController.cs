using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
using Offers.Service.Model;

namespace Offers.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly IGraphClient _client;

        public OfferController(IGraphClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> Get()
        {
            var offers = await _client.Cypher.Match("(n: Offer)")
                                                  .Return(n => n.As<Offer>()).ResultsAsync;

            return Ok(offers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> GetById(Guid id)
        {
            var offer = await _client.Cypher.Match("(d:Offer)")
                                                  .Where((Offer d) => d.Id == id)
                                                  .Return(d => d.As<Offer>()).ResultsAsync;

            return Ok(offer.LastOrDefault());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Offer offer)
        {
            await _client.Cypher.Create("(d:Offer $offer)")
                                .WithParam("offer", offer)
                                .ExecuteWithoutResultsAsync();

            return Ok();
        }

        [HttpGet("{offerId}/applied/{userId}/")]
        public async Task<IActionResult> ApplyForOffer(Guid offerId, Guid userId)
        {
            await _client.Cypher.Match("(d:User), (e:Offer)")
                                .Where((User d, Offer e) => d.id == userId && e.Id == offerId)
                                .Create("(d)-[r:applied]->(e)")
                                .ExecuteWithoutResultsAsync();

            return Ok();
        }


    }
}