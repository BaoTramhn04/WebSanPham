using Microsoft.EntityFrameworkCore;
using WebProductManagement.Data;
using WebProductManagement.Models;               
using WebProductManagement.Repositories.Interfaces;

namespace WebProductManagement.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _context.Products.ToListAsync();

        public async Task<Product?> GetByIdAsync(int id)
            => await _context.Products.FindAsync(id);

        public async Task AddAsync(Product product)
            => await _context.Products.AddAsync(product);

        public async Task UpdateAsync(Product product)
            => _context.Products.Update(product);

        public async Task DeleteAsync(int id)
        {
            var p = await GetByIdAsync(id);
            if (p != null)
                _context.Products.Remove(p);
        }

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();

        // ✅ Hàm tìm kiếm + phân trang
        public async Task<PagedResult<Product>> GetPagedAsync(string? search, int page, int pageSize)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var keyword = search.Trim().ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(keyword));
            }

            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var items = await query
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Product>
            {
                Items = items,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Page = page,
                PageSize = pageSize
            };
        }
    }
}
