using System;
using System.Collections.Generic;
using Business;
using Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service_fee_backend;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WritedCustomerController : ControllerBase
    {
        private IWritedCustomerService _customerService;
        public WritedCustomerController(IWritedCustomerService service){
            _customerService = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           var result =_customerService.GetAll();
          return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] WritedCustomer customer)
        {
           _customerService.Add(customer);
          return Ok();
        }

        [HttpPost("delete")] 
        public IActionResult DeleteCustomer([FromBody] WritedCustomer customer)
        {
           _customerService.Delete(customer);
          return Ok();
        }

        
         [HttpPost("file")]
        public List<object> AddFile(IFormFile file)
        {
           var result = FileHelper.PostUpload(file);
           return result;
        }
    }
}
