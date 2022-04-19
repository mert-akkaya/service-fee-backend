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
    public class FeeCustomerController : ControllerBase
    {
        private IFeeCustomerService _customerService;
        public FeeCustomerController(IFeeCustomerService service){
            _customerService = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           var result =_customerService.GetAll();
          return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] FeeCustomer customer)
        {
           _customerService.Add(customer);
          return Ok();
        }

        [HttpPost("delete")]
        public IActionResult DeleteCustomer([FromBody] FeeCustomer customer)
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
