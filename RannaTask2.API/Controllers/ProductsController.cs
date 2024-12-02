using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RannaTask2.Business;
using RannaTask2.Business.Dtos;
using RannaTask2.DataAccess.Entities;
using System.Threading.Tasks;

namespace RannaTask2.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ProductsController : ControllerBase
	{
		private readonly ProductManager _productManager;

		public ProductsController()
		{
			_productManager = new ProductManager();
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var products = await _productManager.GetAllAsync();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var product = await _productManager.GetByIdAsync(id);
			return product == null ? NotFound() : Ok(product);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] ProductDTO productDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var product = new Product
			{
				Name = productDto.Name,
				Code = productDto.Code,
				Price = productDto.Price,
				ImageUrl = productDto.ImageUrl,
				CreatedDate = DateTime.UtcNow 
			};

			await _productManager.AddAsync(product);

			return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] ProductDTO productDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingProduct = await _productManager.GetByIdAsync(id);
			if (existingProduct == null)
			{
				return NotFound($"Product with ID {id} not found.");
			}

			existingProduct.Name = productDto.Name;
			existingProduct.Code = productDto.Code;
			existingProduct.Price = productDto.Price;
			existingProduct.ImageUrl = productDto.ImageUrl;

			await _productManager.UpdateAsync(existingProduct);

			return NoContent();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _productManager.DeleteAsync(id);
			return NoContent();
		}
	}
}
