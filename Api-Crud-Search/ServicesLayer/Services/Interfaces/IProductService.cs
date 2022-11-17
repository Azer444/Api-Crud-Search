using DomainLayer.Entities;
using ServicesLayer.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(ProductCreateDto product);
        Task UpdateAsync(int id, ProductUpdateDto product);
        Task DeleteAsync(int id);
        Task<List<ProductListDto>> GetAllAsync();
    }
}
