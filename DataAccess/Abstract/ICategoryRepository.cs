using StokApp.Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.DataAccess.Abstract
{
    public interface ICategoryRepository
    {
        Task AddCategory(Category category);
        Task<List<Category>> GetCategories(string searchTerm); 
        Task<List<Category>> GetCategoriesId(int id); 
        Task<Category> CategoryExists(string name); 
        Task<Category> Update(Category category, int id);
        Task<Category> CategoryExistsId(int id);
        Task<Category> GetCategory(int id); 
        Task Delete(Category category);
        Task<List<Category>> GetAll();
       

    }
}
