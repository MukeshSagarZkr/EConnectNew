using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using CompanyMicroservice.Repository;


namespace CompanyMicroservice.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyRepository _CompanyRepository;

		public CompanyController(ICompanyRepository companyRepository)
		{
			_CompanyRepository = companyRepository;
		}

		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<Company>>> GetCompany()
		{
			return Ok(await _CompanyRepository.GetCompanyAsync());
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<Company>> GetCompany(int id)
		{
			var Company = await _CompanyRepository.GetCompanyByIdAsync(id);
			if (Company == null)
			{
				return NotFound(new { message = "Company not found" });
			}
			return Ok(Company);
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult> AddCompany([FromBody] Company company)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _CompanyRepository.AddCompanyAsync(company);
			return CreatedAtAction(nameof(GetCompany), new { id = company.CompanyId }, company);
		}

		[HttpPut("{id}")]
		[Authorize]
		public async Task<ActionResult> UpdateCompany(int id, [FromBody] Company company)
		{
			if (id != company.CompanyId)
			{
				return BadRequest(new { message = "Company ID mismatch" });
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingCompany = await _CompanyRepository.GetCompanyByIdAsync(id);
			if (existingCompany == null)
			{
				return NotFound(new { message = "Company not found" });
			}

			await _CompanyRepository.UpdateCompanyAsync(company);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[Authorize]
		public async Task<ActionResult> DeleteLogin(int id)
		{
			var existingCompany = await _CompanyRepository.GetCompanyByIdAsync(id);
			if (existingCompany == null)
			{
				return NotFound(new { message = "Company not found" });
			}

			await _CompanyRepository.DeleteCompanyAsync(id);
			return NoContent();
		}
	}
}
