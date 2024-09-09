using Core.Dtos.CategoryDtos;
using Core.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategoreService
    {
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto?> Get(int id);
        Task Edit(EditCategorytDto model);
        Task Create(CreateCategoryDto model);
        Task Delete(int id);
    }
}
