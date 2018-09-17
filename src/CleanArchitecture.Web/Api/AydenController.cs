using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.ApiModels;
using CleanArchitecture.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Api
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class AydenController : Controller
    {
        private readonly IRepository<AydenItem> _aydenRepository;


        public AydenController(IRepository<AydenItem> aydenRepository)
        {
            _aydenRepository = aydenRepository;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public IActionResult List()
        {

            return Ok();
        }

        // POST: api/ToDoItems
        [HttpPost]
        public IActionResult Post()
        {
            AydenItem item = new AydenItem
            {
                EncryptedPersonalAndPaymentData = HttpContext.Request.Form["adyen-encrypted-data"],
                Amount = 5000,
                Currency = "GBP"
            };

            var a = _aydenRepository.Add(item);

            a.RequestPaymentFulfilment();
            _aydenRepository.Update(a);
            
            
            return Ok(a);
        }
    }
}
