using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServicesLayer.DTOs.Product;
using ServicesLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(ProductCreateDto product)
        {
            await _repo.Create(_mapper.Map<Product>(product));
        }

        public async Task DeleteAsync(int id)
        {
            Product product = await _repo.Get(id);
            await _repo.Delete(product);
        }

        public async Task UpdateAsync(int id, ProductUpdateDto product)
        {
            var dbProduct = await _repo.Get(id);

            _mapper.Map(product, dbProduct);

            await _repo.Update(dbProduct);
        }

        public async Task<List<ProductListDto>> GetAllAsync()
        {
            return _mapper.Map<List<ProductListDto>>(await _repo.GetAll());
        }
    }
}
