using Microsoft.AspNetCore.Mvc;
using AgentApp.Models;
using AgentApp.DTO;
using AgentApp.Services;
using AutoMapper;

namespace AgentApp.Controller
{
    [ApiController]
    [Route("jobs")]
    public class JobController : ControllerBase
    {
        public readonly JobService _jobService;
        public readonly CompanyService _companyService;
        public readonly IMapper _mapper;

        public JobController(JobService jobService, CompanyService companyService, IMapper mapper)
        {
            _jobService = jobService;
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Job>> Post(JobDTO jobDTO)
        {
            if(await _companyService.GetCompanyById(jobDTO.CompanyId) == null)
            {
                return NotFound("Company not found.");
            }

            var job = _mapper.Map<Job>(jobDTO); 
            await _jobService.CreateJob(job);

            return Ok();
        }

        [HttpGet("byCompany/{id}")]
        public async Task<ActionResult<Job>> GetByCompanyId(Guid id)
        {
            var jobs = (await _jobService.GetAllByCompanyId(id))
                        .Select(job => _mapper.Map<CompanyDTO>(job));
            
            return Ok(jobs);
        }

    }
}