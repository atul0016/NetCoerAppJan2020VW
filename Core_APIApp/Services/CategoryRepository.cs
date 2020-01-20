using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core_APIApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_APIApp.Services
{
    public class CategoryRepository : IRepository<Category, int>
    {
        private AppDataDbContext ctx;
        /// <summary>
        /// inject the DbContext in repository class
        /// </summary>
        /// <param name="ctx"></param>
        public CategoryRepository(AppDataDbContext ctx)
        {
            this.ctx = ctx;
        }
        public  async Task<Category> CreateAsync(Category entity)
        {
            var res = await ctx.Categories.AddAsync(entity);
            await ctx.SaveChangesAsync(); // commit transactions
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // search records based in P.K.
            var res = await ctx.Categories.FindAsync(id);
            if (res != null)
            {
                // remove record
                ctx.Categories.Remove(res);
                await ctx.SaveChangesAsync(); // commit transactions
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await ctx.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await ctx.Categories.FindAsync(id);
        }

        public async Task<Category> UpdateAsync(int id, Category entity)
        {
             var res = await ctx.Categories.FindAsync(id);
            if (res != null)
            {
                res.CategoryId = entity.CategoryId;
                res.CategoryName = entity.CategoryName;
                res.BasePrice = entity.BasePrice;
               // ctx.Entry<Category>(entity).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
                return res;
            }
            return res; // this will return null
        }
    }
}
