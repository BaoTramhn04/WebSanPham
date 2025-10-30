using WebProductManagement.Models;
using WebProductManagement.Repositories.Interfaces;
using WebProductManagement.Services.Interfaces;

namespace WebProductManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) => _repo = repo;

        public async Task<IEnumerable<Product>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Product?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<bool> CreateAsync(Product product)
        {
            await _repo.AddAsync(product);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            await Task.Run(() => _repo.UpdateAsync(product));
            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveAsync();
            return true;
        }
    }
}
