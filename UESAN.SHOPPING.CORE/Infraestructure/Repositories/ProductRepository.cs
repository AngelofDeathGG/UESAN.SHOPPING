using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;

namespace UESAN.SHOPPING.CORE.Infraestructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDBContext _context;

        public ProductRepository(StoreDBContext context)
        {
            _context = context;
        }

        // Obtener todos los productos
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        // Obtener producto por ID
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        // Crear Producto
        public async Task CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        // Actualizar Producto
        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = await _context.Products.Where(p => p.Id == product.Id).FirstOrDefaultAsync();
            if (existingProduct != null)
            {
                existingProduct.Description = product.Description;
                existingProduct.ImageUrl = product.ImageUrl;
                existingProduct.Stock = product.Stock;
                existingProduct.Price = product.Price;
                existingProduct.Discount = product.Discount;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.IsActive = product.IsActive;

                await _context.SaveChangesAsync();
            }
        }

        // Eliminar Producto (Eliminación Lógica)
        public async Task DeleteProductAsync(int id)
        {
            var existingProduct = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (existingProduct != null)
            {
                existingProduct.IsActive = false; // Igual que en Category, solo lo desactivamos
                await _context.SaveChangesAsync();
            }
        }
    }
}