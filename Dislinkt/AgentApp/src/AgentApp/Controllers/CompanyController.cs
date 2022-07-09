using Microsoft.AspNetCore.Mvc;
using AgentApp.Models;
using AgentApp.DTO;
using AgentApp.Services;
using AutoMapper;
using AgentApp.Clients;

namespace AgentApp.Controller
{    
    [ApiController]
    [Route("companies")]
    public class CompanyController : ControllerBase
    {
        public readonly CompanyService _companyService;
        public readonly UserService _userService;
        public readonly JobOfferService _jobOfferService;
        public readonly JobOfferClient _jobOfferClient;
        public readonly IMapper _mapper;
        public CompanyController(CompanyService companyService, UserService userService, JobOfferService jobOfferService, JobOfferClient jobOfferClient, IMapper mapper)
        {
            _companyService = companyService;
            _userService = userService;
            _jobOfferService = jobOfferService;
            _jobOfferClient = jobOfferClient;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetAsync()
        {
            var companies = (await _companyService.GetAll())
                        .Select(company => _mapper.Map<CompanyDTO>(company));

            return Ok(companies);
        }

        [HttpPost("register")]
        public async Task<ActionResult<Company>> Register(CompanyDTO companyDTO)
        {
            if(await _companyService.GetCompanyByName(companyDTO.Name) != null)
            {
                return Conflict();
            }
            if(await _userService.GetUserById(companyDTO.OwnerId) == null)
            {
                return NotFound("User not found.");
            }

            Company company = _mapper.Map<Company>(companyDTO);
            await _companyService.CreateCompany(company);

            return Ok(company);
        }

        [HttpGet("confirm/{id}")]
        public async Task<ActionResult<Company>> ConfirmCompany(Guid id)
        {
            var company = await _companyService.GetCompanyById(id);
            var user = await _userService.GetUserById(company.OwnerId);

            if (company == null)
            {
                return NotFound();
            }

            company.Confirmed = true;
            await _companyService.UpdateCompany(company);

            user.Role = RoleEnum.OWNER;
            await _userService.UpdateUser(user);
            
            return Ok(company);
        }

        [HttpPost("update")]
        public async Task<ActionResult<Company>> UpdateDescription(CompanyUpdateDTO updateDTO)
        {
            var company = await _companyService.GetCompanyByName(updateDTO.Name);

            if (company == null)
            {
                return NotFound();
            }

            company.Description = updateDTO.Description;
            await _companyService.UpdateCompany(company);

            return Ok();
        }

        [HttpPost("jobOffer")]
         public async Task<ActionResult<Company>> CreateJobOffer(JobOfferDTO jobOfferDTO)
         {
            if(await _companyService.GetCompanyByName(jobOfferDTO.CompanyName) == null)
            {
                return NotFound("Company not found.");
            }

            JobOffer offer = _mapper.Map<JobOffer>(jobOfferDTO);
            await _jobOfferService.CreateJobOffer(offer);

            await _jobOfferClient.PostJobOffer(jobOfferDTO);

            return Ok(offer);
         }

         [HttpGet("jobOffers/{companyName}")]
         public async Task<ActionResult<IEnumerable<JobOfferDTO>>> GetJobOffersByCompany(String companyName)
         {
            IEnumerable<JobOfferDTO> offers = (await _jobOfferService.GetAllByCompany(companyName))
                        .Select(offer => _mapper.Map<JobOfferDTO>(offer));

            return Ok(offers);
         }

    }

}