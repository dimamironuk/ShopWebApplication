using AutoMapper;
using Core.Dtos.CategoryDtos;
using Core.Dtos.ProductDtos;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoryService : ICategoreService
    {
        private readonly IRepository<Category> categoryRep;
        private readonly IRepository<Product> productRep;
        private readonly IMapper mapper;
        public CategoryService(IRepository<Category> categoryRep, IMapper mapper, IRepository<Product> productRep)
        {
            this.categoryRep = categoryRep;
            this.productRep = productRep;
            this.mapper = mapper;
        }

        public async Task Create(CreateCategoryDto model)
        {
            await categoryRep.Insert(mapper.Map<Category>(model));
            await categoryRep.Save();
        }

        public async Task Delete(int id)
        {
            var category = await categoryRep.GetById(id);
            if (category == null) return;

            var products = await productRep.GetAll();
            var productsToDelete = products.Where(p => p.CategoryId == id).ToList();

            foreach (var product in productsToDelete)
            {
                await productRep.Delete(product);
            }

            await categoryRep.Delete(category);
            await categoryRep.Save();
        }


        public async Task Edit(EditCategorytDto model)
        {
            categoryRep.Update(mapper.Map<Category>(model));
            await categoryRep.Save();
        }

        public async Task<CategoryDto?> Get(int id)
        {
            var category = await categoryRep.GetById(id);
            if (category == null) return null;

            return mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return mapper.Map<List<CategoryDto>>(await categoryRep.GetAll());
        }
    }
}
