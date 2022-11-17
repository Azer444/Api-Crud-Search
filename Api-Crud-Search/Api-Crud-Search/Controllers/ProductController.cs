using Microsoft.AspNetCore.Mvc;
using ServicesLayer.DTOs.Product;
using ServicesLayer.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Api_Crud_Search.Controllers
{
    public class ProductController : AppController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductCreateDto product)
        {
            await _productService.CreateAsync(product);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([Required] int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

        }

          [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute][Required] int id, ProductUpdateDto product)
        {
            try
            {
                await _productService.UpdateAsync(id,product);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }





    }
}
