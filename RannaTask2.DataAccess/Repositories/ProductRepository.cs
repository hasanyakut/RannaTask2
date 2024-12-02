using RannaTask2.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RannaTask2.DataAccess.Repositories
{
	public class ProductRepository
	{
		public async Task<List<Product>> GetAllAsync()
		{
			using (var context = new ProductContext())
			{
				return await context.Products.ToListAsync();
			}
		}

		public async Task<Product> GetByIdAsync(int id)
		{
			using (var context = new ProductContext())
			{
				return await context.Products.FindAsync(id);
			}
		}

		public async Task AddAsync(Product product)
		{
			using (var context = new ProductContext())
			{
				context.Products.Add(product);
				await context.SaveChangesAsync();
			}
		}

		public async Task UpdateAsync(Product product)
		{
			using (var context = new ProductContext())
			{
				context.Products.Update(product);
				await context.SaveChangesAsync();
			}
		}

		public async Task DeleteAsync(int id)
		{
			using (var context = new ProductContext())
			{
				var product = await context.Products.FindAsync(id);
				if (product != null)
				{
					context.Products.Remove(product);
					await context.SaveChangesAsync();
				}
			}
		}
	}
}
