using Microsoft.EntityFrameworkCore;
using StokApp.DataAccess.Abstract;
using StokApp.DataAccess.Concrete.EntityFramework.Conctext;
using StokApp.Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public EfProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            await Task.Run(() => { _context.Set<Product>().Remove(product); });
            _context.SaveChanges();
        }

        public async Task<List<Product>> GetAll()
        {
            var category = await _context.Products.ToListAsync();
            return category;
        }

        public Task<Product> GetProduct(int id)
        {
            var category = _context.Products.FirstOrDefaultAsync(q => q.Id == id);
            return category;
        }

        public async Task<List<Product>> GetProducts(string searchTerm)
        {
            return await _context.Products.Where(a => a.ProductName.ToLower().Trim().Contains(searchTerm.ToLower()))
                                            .Take(10)
                                            .ToListAsync();
        }

        public async Task<List<Product>> GetProductsId(int id)
        {
            return await _context.Products.Where(a => a.Id == id).ToListAsync();
        }

        public async Task<Product> ProductExists(string name)
        {
            var exist = await _context.Products.FirstOrDefaultAsync(a => a.ProductName.Trim() == name.Trim());
            return exist;
        }

        public async Task<Product> ProductExistsId(int id)
        {
            var exist = await _context.Products.FirstOrDefaultAsync(a => a.Id == id);
            return exist;
        }

        public Task<Product> Update(Product product, int id)
        {
            if (product == null)
            {
                throw new ArgumentNullException("item");
            }

            var item = _context.Products.FirstOrDefaultAsync(q => q.Id == id);

            if (item == null)
            {
                throw new ArgumentNullException("product");
            }
            _context.Products.Update(product);
            _context.SaveChanges();
            return item;
        }
    }
}
