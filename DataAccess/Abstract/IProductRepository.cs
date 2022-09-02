using StokApp.Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.DataAccess.Abstract
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<List<Product>> GetProducts(string searchTerm); //adını yazdığımızda getir
        Task<List<Product>> GetProductsId(int id); //id yazdığımızda getir
        Task<Product> ProductExists(string name);
        Task<Product> Update(Product product, int id);
        Task<Product> ProductExistsId(int id);
        Task<Product> GetProduct(int id); //tekil getir
        Task Delete(Product product);
        Task<List<Product>> GetAll();
        
      
    }
}
