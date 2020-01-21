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
   // [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category, int> catRepository;    
        public CategoryController(IRepository<Category, int> catRepository)
        {
            this.catRepository = catRepository;
        }

        [HttpGet] // represent the HTTP GET request
        public async Task<IActionResult> GetAsync()
        {
            var res = await catRepository.GetAsync();
            return Ok(res);
        }

        [HttpGet("{id}")] // represent the HTTP GET request with {id} as header parameter
        public async Task<IActionResult> GetAsync(int id)
        {
            var res = await catRepository.GetAsync(id);
            return Ok(res);
        }
        //[HttpPost("{CategoryId}/{CategoryName}/{BasePrice}")]
        // public async Task<IActionResult> PostAsync([FromBody]Category category)
        //public async Task<IActionResult> PostAsync([FromQuery]Category category)
        // public async Task<IActionResult> PostAsync([FromRoute]Category category)
        [HttpPost]   
       public async Task<IActionResult> PostAsync([FromForm]Category category)
        {
            // checking for Model Validation
            if (ModelState.IsValid)
            {
                var res = await catRepository.CreateAsync(category);
                return Ok(res);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Category category)
        {
            // checking for Model Validation
            if (ModelState.IsValid)
            {
                var res = await catRepository.UpdateAsync(id,category);
                return Ok(res);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
                var res = await catRepository.DeleteAsync(id);
                return Ok(res);
        }
    }
}