﻿using App.Domain.Core.Product.Dtos;
namespace App.Domain.Core.Product.Contacts.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();
        Task<int> Set(ProductDto dto);
        Task<ProductDto> Get(int id);
        Task<ProductDto> Get(string name);
        Task Update(ProductDto dto);
        Task Delete(int id);
        Task EnsureDoesNotExist(string name);
        Task EnsureExists(string name);
        Task EnsureExists(int id);
    }
}