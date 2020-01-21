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
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product, int> prdRepository;
        public ProductController(IRepository<Product, int> prdRepository)
        {
            this.prdRepository = prdRepository;
        }
    }
}