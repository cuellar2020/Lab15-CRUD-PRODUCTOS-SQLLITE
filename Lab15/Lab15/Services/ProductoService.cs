﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Lab15.Models;

namespace Lab15.Services
{
    public class ProductoService 
    {
        private DatabaseContext getContext()
        {
            return new DatabaseContext();
        }

        public async Task<List<Producto>> GetAllProductos()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Productos.ToListAsync();
            return res;
        }

        public async Task<int> UpdateProducto(Producto obj)
        {
            var _dbContext = getContext();
            _dbContext.Productos.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

        public int InsertProducto(Producto obj)
        {
            var _dbContext = getContext();
            _dbContext.Productos.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        public int DeleteProducto(Producto obj)
        {

            var _dbContext = getContext();
            _dbContext.Productos.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
    }
}