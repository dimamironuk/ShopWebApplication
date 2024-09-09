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
    public class ProductService : IProductService
    {
        private readonly ShopDbContext context;
        private readonly IMapper mapper;
        public ProductService(ShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task Create(CreateProductDto model)
        {
            context.Products.Add(mapper.Map<Product>(model));
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null) return;

            context.Products.Remove(product);

            await context.SaveChangesAsync();
        }

        public async Task Edit(EditProductDto model)
        {
            context.Products.Update(mapper.Map<Product>(model));
            await context.SaveChangesAsync();
        }

        public async Task<ProductDto?> Get(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null) return null;

            return mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return mapper.Map<List<ProductDto>>(await context.Products.ToListAsync());
        }
    }
}
