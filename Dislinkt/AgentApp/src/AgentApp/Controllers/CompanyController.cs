using Microsoft.AspNetCore.Mvc;
using AgentApp.Models;
using AgentApp.DTO;
using AgentApp.Services;
using AutoMapper;

namespace AgentApp.Controller
{    
    [ApiController]
    [Route("companies")]
    public class CompanyController : ControllerBase
    {
        public readonly CompanyService _companyService;
        public readonly UserService _userService;
        public readonly IMapper _mapper;
        public CompanyController(CompanyService companyService, UserService userService, IMapper mapper)
        {
            _companyService = companyService;
            _userService = userService;
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
    }

}