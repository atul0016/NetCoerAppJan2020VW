using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core_APIApp.Models;
using Core_APIApp.Services;

namespace Core_APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombineController : ControllerBase
    {
        private readonly IRepository<Category, int> catRepo;
        private readonly IRepository<Product, int> prdRepo;
        public CombineController(IRepository<Category, int> catRepo, IRepository<Product, int> prdRepo)
        {
            this.catRepo = catRepo;
            this.prdRepo = prdRepo;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(CatProduct catProduct)
        {
            var cat = await catRepo.CreateAsync(catProduct.Category);
            foreach (var prd in catProduct.Products)
            {
                prd.CategoryRowId = cat.CategoryRowId;
                await prdRepo.CreateAsync(prd);
            }
            return Ok();
        }

    }
}