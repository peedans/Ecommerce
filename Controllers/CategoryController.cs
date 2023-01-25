using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/product/[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ECommerceContext _dbContext;

        public CategoryController(ILogger<CategoryController> logger, ECommerceContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entry = _dbContext.Add(category);
            _dbContext.SaveChanges();

            var newCategory = entry.Entity;
            return CreatedAtAction(
                nameof(GetCategoryById),
                new { id = newCategory.Id },
                newCategory
            );
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categories = _dbContext.Categories!.ToList();
            if (categories == null || !categories.Any())
            {
                return NotFound("No Categories Found");
            }
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCategoryById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            var existingCategory = _dbContext.Categories!.FirstOrDefault(category => category.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            return Ok(existingCategory);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            var existingCategory = _dbContext.Categories!.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Name = category.Name;
            _dbContext.SaveChanges();
            return Ok(existingCategory);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            var existingCategory = _dbContext.Categories!.Find(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            _dbContext.Categories.Remove(existingCategory);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}