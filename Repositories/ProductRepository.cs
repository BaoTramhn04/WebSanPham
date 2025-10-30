using Microsoft.EntityFrameworkCore;
using WebProductManagement.Data;
using WebProductManagement.Models;
using WebProductManagement.Repositories.Interfaces;

namespace WebProductManagement.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();
        public async Task<Product?> GetByIdAsync(int id) => await _context.Products.FindAsync(id);
        public async Task AddAsync(Product product) => await _context.Products.AddAsync(product);
        public async Task UpdateAsync(Product product) => _context.Products.Update(product);
        public async Task DeleteAsync(int id)
        {
            var p = await GetByIdAsync(id);
            if (p != null) _context.Products.Remove(p);
        }
        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
