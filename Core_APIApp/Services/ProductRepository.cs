using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core_APIApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_APIApp.Services
{
    public class ProductRepository : IRepository<Product, int>
    {
        private AppDataDbContext ctx;
        /// <summary>
        /// inject the DbContext in repository class
        /// </summary>
        /// <param name="ctx"></param>
        public ProductRepository(AppDataDbContext ctx)
        {
            this.ctx = ctx;
        }
        public  async Task<Product> CreateAsync(Product entity)
        {
            var res = await ctx.Products.AddAsync(entity);
            await ctx.SaveChangesAsync(); // commit transactions
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // search records based in P.K.
            var res = await ctx.Products.FindAsync(id);
            if (res != null)
            {
                // remove record
                ctx.Products.Remove(res);
                await ctx.SaveChangesAsync(); // commit transactions
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await ctx.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await ctx.Products.FindAsync(id);
        }

        public async Task<Product> UpdateAsync(int id, Product entity)
        {
             var res = await ctx.Products.FindAsync(id);
            if (res != null)
            {
                res.ProductId = entity.ProductId;
                res.ProductName = entity.ProductName;
                res.Manufacturer = entity.Manufacturer;
                res.Price = entity.Price;
                res.CategoryRowId = entity.CategoryRowId;
               // ctx.Entry<Product>(entity).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
                return res;
            }
            return res; // this will return null
        }
    }
}
