using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        private readonly ECommerceContext _dbContext;

        public ProductController(ILogger<ProductController> logger, ECommerceContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exists = _dbContext.Products!.Any(p => p.Id == product.Id);
            if (exists)
            {
                return Conflict();
            }
            var entry = _dbContext.Add(product);
            _dbContext.SaveChanges();

            var newProduct = entry.Entity;
            return CreatedAtAction(
                nameof(GetProductByid),
                new { id = newProduct.Id },
                newProduct
            );
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _dbContext.Products!.ToList();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProductByid(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            var existingProduct = _dbContext.Products!.FirstOrDefault(product => product.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            return Ok(existingProduct);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            var existingProduct = _dbContext.Products!.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return BadRequest("Product not found");
            }
            existingProduct.Name = product.Name;
            existingProduct.IsActive = product.IsActive;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.UpdatedAt = DateTime.Now;
            _dbContext.SaveChanges();
            return Ok(existingProduct);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            var existingProduct = _dbContext.Products!.Find(id);
            if (existingProduct == null)
            {
                return BadRequest("Product not found");
            }
            _dbContext.Products.Remove(existingProduct);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}