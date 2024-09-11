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
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRep;
        private readonly IMapper mapper;
        public ProductService(IRepository<Product> productRep, IMapper mapper)
        {
            this.productRep = productRep;
            this.mapper = mapper;
        }

        public async Task Create(CreateProductDto model)
        {
            await productRep.Insert(mapper.Map<Product>(model));
            await productRep.Save();
        }

        public async Task Delete(int id)
        {
            var product = await productRep.GetById(id);
            if (product == null) return;

            await productRep.Delete(id);
            await productRep.Save();
        }

        public async Task Edit(EditProductDto model)
        {
            await productRep.Update(mapper.Map<Product>(model));
            await productRep.Save();
        }

        public async Task<ProductDto?> Get(int id)
        {
            var product = await productRep.GetById(id);
            if (product == null) return null;

            return mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return mapper.Map<List<ProductDto>>(await productRep.GetAll());
        }
    }
}
