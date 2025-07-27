using FromScratch.Data;
using FromScratch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FromScratch.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var products = await _appDbContext.products.ToListAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (!string.IsNullOrWhiteSpace(product.Name))
            {
                await _appDbContext.AddAsync(product);
                await _appDbContext.SaveChangesAsync();

                // add response dto to avoid exposing all columns 
                return Ok(product);
            }
            else
                return BadRequest("product name is required");
        }
    }
}
