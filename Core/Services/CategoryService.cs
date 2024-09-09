using AutoMapper;
using Core.Dtos.CategoryDtos;
using Core.Dtos.ProductDtos;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
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
        private readonly ShopDbContext context;
        private readonly IMapper mapper;
        public CategoryService(ShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task Create(CreateCategoryDto model)
        {
            context.Categories.Add(mapper.Map<Category>(model));
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category == null) return;

            var products = await context.Products.Where(p => p.CategoryId == id).ToListAsync();
            context.Products.RemoveRange(products);

            context.Categories.Remove(category);

            await context.SaveChangesAsync();
        }

        public async Task Edit(EditCategorytDto model)
        {
            context.Categories.Update(mapper.Map<Category>(model));
            await context.SaveChangesAsync();
        }

        public async Task<CategoryDto?> Get(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category == null) return null;

            return mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return mapper.Map<List<CategoryDto>>(await context.Categories.ToListAsync());
        }
    }
}
