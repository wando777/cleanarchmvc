using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task AddCategoryAsync(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> GetByID(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveCategoryAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
