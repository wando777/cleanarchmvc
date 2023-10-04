using System;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _productContext;

        public ProductRepository(ApplicationDbContext product)
        {
            _productContext = product;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            var product = await _productContext.Products.FindAsync(id);
            return product;
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            //eager loading
            var productCategory = await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
            return productCategory;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _productContext.Products.ToListAsync();
            return products;
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}

