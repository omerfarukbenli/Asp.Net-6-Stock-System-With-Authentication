using StokApp.Entities.Concrete.Bases;
using StokApp.Entities.Concrete.Dtos;
using StokApp.Entities.Concrete.Models;
using StokApp.Entities.Concrete.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.Business.Abstract
{
    public interface ICategoryService
    {
        Task<IResponse<List<GetCategoryDto>>> GetCategories(string searchTerm);
        Task<IResponse<GetCategoryDto>> Post(CreateCategoryDto categoryDto);
        Task<IResponse<List<GetCategoryDto>>> GetCategoriesID(int id);
        Task<IResponse<UpdateCategoryDto>> Update(UpdateCategoryDto categoryDto, int id);
        Task<IResponse<bool>> DeleteByIdAsync(int id);
        Task<IResponse<List<GetListCategory>>> GetAllCategory();

    }
}
