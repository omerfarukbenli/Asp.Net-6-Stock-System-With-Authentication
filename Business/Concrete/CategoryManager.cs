using AutoMapper;
using Microsoft.AspNetCore.Http;
using StokApp.Business.Abstract;
using StokApp.DataAccess.Abstract;
using StokApp.Entities.Concrete.Bases;
using StokApp.Entities.Concrete.Dtos;
using StokApp.Entities.Concrete.Models;
using StokApp.Entities.Concrete.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResponse<bool>> DeleteByIdAsync(int id)
        {
            try
            {
                var category = await _unitOfWork.Category.GetCategory(id);
                if (category != null)
                {
                    await _unitOfWork.Category.Delete(category);

                }
                else
                {
                    throw new ValidationException("kategori bulunmadı");
                }
                var response = new Response<bool>()
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = true
                };
                return response;
            }
            catch (Exception ex)
            {

                return new Response<bool>()
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = true
                };
            }
        }

        public async Task<IResponse<List<GetListCategory>>> GetAllCategory()
        {
            try
            {
                var a = await _unitOfWork.Category.GetAll();
                var list = _mapper.Map<List<GetListCategory>>(a);
                var response = new Response<List<GetListCategory>>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = list
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<GetListCategory>>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        public async Task<IResponse<List<GetCategoryDto>>> GetCategories(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    throw new ValidationException("Arama bölümü boş olamaz");
                }
                var a = _mapper.Map<List<GetCategoryDto>>(await _unitOfWork.Category.GetCategories(searchTerm));
                var b = new Response<List<GetCategoryDto>>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = a
                };
                return b;
            }
            catch (Exception ex)
            {

                return new Response<List<GetCategoryDto>>()
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }
        

        public async Task<IResponse<List<GetCategoryDto>>> GetCategoriesID(int id)
        {
            var category = await _unitOfWork.Category.GetCategoriesId(id);
            var list = _mapper.Map<List<GetCategoryDto>>(category);
            if (category.Count > 0)
            {
                return new Response<List<GetCategoryDto>>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = list
                };
            }
            else
            {
                return new Response<List<GetCategoryDto>>
                {
                    Message = "Böyle bir kategori bulunamadı.",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        public async Task<IResponse<GetCategoryDto>> Post(CreateCategoryDto categoryDto)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDto);
                var existingCat = await _unitOfWork.Category.CategoryExists(categoryDto.CategoryName);

                if (existingCat != null)
                {
                    var existingCategoryForGetDto = _mapper.Map<GetCategoryDto>(existingCat);

                }
                await _unitOfWork.Category.AddCategory(category);
                var categoryForGetDto = _mapper.Map<GetCategoryDto>(category);
                var response = new Response<GetCategoryDto>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = categoryForGetDto
                };
                return response;
            }
            catch (Exception ex)
            {
                return new Response<GetCategoryDto>()
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };

            }
        }

        public async Task<IResponse<UpdateCategoryDto>> Update(UpdateCategoryDto categoryDto, int id)
        {
            try
            {
                var ownerEntity = await _unitOfWork.Category.GetCategory(id);
                _mapper.Map<GetCategoryDto>(ownerEntity);
                _mapper.Map(categoryDto, ownerEntity);
                await _unitOfWork.Category.Update(ownerEntity, id);
                var response = new Response<UpdateCategoryDto>()
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = categoryDto
                };
                return response;


            }
            catch (Exception ex)
            {

                return new Response<UpdateCategoryDto>()
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }

        
    }
    }
}
