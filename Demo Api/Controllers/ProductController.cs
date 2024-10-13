using Demo_Api.Data;
using Demo_Api.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly demoDBContext _demoDBContext;

        public ProductController(demoDBContext demoDBContext) => _demoDBContext = demoDBContext;

        [HttpGet]

        public ActionResult<IEnumerable<Product>> Get()
        {
            return _demoDBContext.Products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> GetById(int id) {


            return await _demoDBContext.Products.Where(X => X.id == id).SingleOrDefaultAsync();
        }


        [HttpPost]

        public async Task<ActionResult> Create(Product product)
        {
            await _demoDBContext.Products.AddAsync(product);
            await _demoDBContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.id }, product);


        }


        [HttpPut]

        public async Task<ActionResult> Update(Product product)
        {
            _demoDBContext.Products.Update(product);
            await _demoDBContext.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var productGetByIdResult = await GetById(id);
            if(productGetByIdResult.Value is null)
                return NotFound();

            _demoDBContext.Remove(productGetByIdResult.Value);
            return Ok();
        }

        
    


    }
}
