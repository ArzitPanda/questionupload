using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using questionupload.Data.Model;
using questionupload.Services;

namespace questionupload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin")]
    public class AccessibilityController : ControllerBase
    {
        private readonly IAccessibilityService _accessibilityService;

        public AccessibilityController(IAccessibilityService accessibilityService)
        {
            _accessibilityService = accessibilityService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccessibilityById(int id)
        {
            var accessibility = await _accessibilityService.GetAccessibilityByIdAsync(id);
            if (accessibility == null)
            {
                return NotFound();
            }
            return Ok(accessibility);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccessibilities()
        {
            var accessibilities = await _accessibilityService.GetAllAccessibilitiesAsync();
            return Ok(accessibilities);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccessibility([FromBody] Accessibility accessibility)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAccessibility = await _accessibilityService.CreateAccessibilityAsync(accessibility);
            return CreatedAtAction(nameof(GetAccessibilityById), new { id = createdAccessibility.Id }, createdAccessibility);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccessibility(int id, [FromBody] Accessibility accessibility)
        {
            if (id != accessibility.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAccessibility = await _accessibilityService.GetAccessibilityByIdAsync(id);
            if (existingAccessibility == null)
            {
                return NotFound();
            }

            await _accessibilityService.UpdateAccessibilityAsync(accessibility);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccessibility(int id)
        {
            var existingAccessibility = await _accessibilityService.GetAccessibilityByIdAsync(id);
            if (existingAccessibility == null)
            {
                return NotFound();
            }

            await _accessibilityService.DeleteAccessibilityAsync(id);
            return NoContent();
        }
    }
}
