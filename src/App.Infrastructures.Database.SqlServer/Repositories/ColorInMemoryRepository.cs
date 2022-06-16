﻿using App.Domain.Core.BaseDataAgg.Entities;
using App.Domain.Core.ProductAgg.Contracts.Repositories;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class ColorInMemoryRepository : IColorRepository
    {

        private readonly AppDbContext _eshop;

        public ColorInMemoryRepository(AppDbContext appDbContext)
        {
            _eshop = appDbContext;
        }

        public void Create(Color color)
        {
            _eshop.Colors.Add(color);
            _eshop.SaveChanges();
        }
        public void Edit(Color model)
        {
            var color = _eshop.Colors.First(p => p.Id == model.Id);
            color.Name = model.Name;
            color.Code = model.Code;
            color.CreationDate = model.CreationDate;
            _eshop.SaveChanges();
        }
        public void Delete(int id)
        {
            var color = _eshop.Colors.First(p => p.Id == id);
            _eshop.Colors.Remove(color);
            _eshop.SaveChanges();
        }


        public List<Color> GetAll()
        {
            return _eshop.Colors.Include(b => b.ProductColors).ToList();
        }
        public Color GetById(int id)
        {
            return _eshop.Colors.First(p => p.Id == id);
        }
    }
}