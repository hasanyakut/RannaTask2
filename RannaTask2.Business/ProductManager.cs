using RannaTask2.DataAccess.Entities;
using RannaTask2.DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RannaTask2.Business
{
	public class ProductManager
	{
		private readonly ProductRepository _repository;

		public ProductManager()
		{
			_repository = new ProductRepository();
		}

		public Task<List<Product>> GetAllAsync() => _repository.GetAllAsync();
		public Task<Product> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
		public Task AddAsync(Product product) => _repository.AddAsync(product);
		public Task UpdateAsync(Product product) => _repository.UpdateAsync(product);
		public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
	}
}
