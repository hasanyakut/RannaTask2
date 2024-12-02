using Microsoft.EntityFrameworkCore;
using RannaTask2.DataAccess.Entities;

namespace RannaTask2.DataAccess
{
	public class ProductContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=HASAN\\SQLEXPRESS;Database=RannaTask2;Trusted_Connection=True;");
		}

		public DbSet<Product> Products { get; set; }
	}
}
