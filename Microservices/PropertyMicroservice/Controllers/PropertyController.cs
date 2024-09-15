using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyMicroservice.Models;
using PropertyMicroservice.Repository;

namespace PropertyMicroservice.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PropertyController : ControllerBase
	{
		private readonly IPropertyRepository _propertyRepository;

		public PropertyController(IPropertyRepository propertyRepository)
		{
			_propertyRepository = propertyRepository;
		}

		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<Property>>> GetProperty()
		{
			return Ok(await _propertyRepository.GetPropertyAsync());
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<Property>> GetProperty(int id)
		{
			var property = await _propertyRepository.GetPropertyByIdAsync(id);
			if (property == null)
			{
				return NotFound(new { message = "Property not found" });
			}
			return Ok(property);
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult> AddProperty([FromBody] Property property)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _propertyRepository.AddPropertyAsync(property);
			return CreatedAtAction(nameof(GetProperty), new { id = property.PropertyId }, property);
		}

		[HttpPut("{id}")]
		[Authorize]
		public async Task<ActionResult> UpdateProperty(int id, [FromBody] Property property)
		{
			if (id != property.PropertyId)
			{
				return BadRequest(new { message = "Property ID mismatch" });
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingProperty = await _propertyRepository.GetPropertyByIdAsync(id);
			if (existingProperty == null)
			{
				return NotFound(new { message = "Property not found" });
			}

			await _propertyRepository.UpdatePropertyAsync(property);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[Authorize]
		public async Task<ActionResult> DeleteLogin(int id)
		{
			var existingProperty = await _propertyRepository.GetPropertyByIdAsync(id);
			if (existingProperty == null)
			{
				return NotFound(new { message = "Property not found" });
			}

			await _propertyRepository.DeletePropertyAsync(id);
			return NoContent();
		}
	}
}
