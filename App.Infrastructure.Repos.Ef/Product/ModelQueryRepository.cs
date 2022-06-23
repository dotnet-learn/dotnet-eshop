﻿using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repos.Ef.Product
{
    public class ModelQueryRepository : IModelQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public ModelQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ModelDto?> Get(int id)
        {
            var model = await _appDbContext.Models.Where(x => x.Id == id)
                .Select(x => new ModelDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate,
                    BrandId = x.BrandId,
                    ParentModelId = x.ParentModelId
                }).FirstOrDefaultAsync();
            return model;
        }

        public async Task<ModelDto?> Get(string name)
        {
            var model = await _appDbContext.Models.Where(x => x.Name == name)
                .Select(x => new ModelDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate,
                    BrandId = x.BrandId,
                    ParentModelId = x.ParentModelId
                }).SingleOrDefaultAsync();
            return model;
        }

        public async Task<List<ModelDto>> GetAll()
        {
            var models = await _appDbContext.Models.Select(x => new ModelDto()
            {
                Id = x.Id,
                Name = x.Name,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate,
                BrandId = x.BrandId,
                ParentModelId = x.ParentModelId
            }).ToListAsync();
            return models;
        }
    }
}