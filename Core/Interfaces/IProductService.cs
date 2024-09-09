using Core.Dtos.CategoryDtos;
using Core.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto?> Get(int id);
        Task Edit(EditProductDto model);
        Task Create(CreateProductDto model);
        Task Delete(int id);
    }
}
