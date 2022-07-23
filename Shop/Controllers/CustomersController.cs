using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Data.Services;
using Shop.Data.ViewMidels;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public CustomersService _customersService;
        public CustomersController(CustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            var allCustomers = _customersService.GetAllCustomers();
            return Ok(allCustomers);
        }

        [HttpGet("GetCustomerById/{customerId}")]
        public IActionResult GetCustomerById(int customerId)
        {
            var customer = _customersService.GetCustomerById(customerId);
            return Ok(customer);
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer([FromBody]CustomerVM newCustomer)
        {
            _customersService.AddCustomer(newCustomer);
            return Ok();
        }

        [HttpPut("UpdatedCustomerById/{customerId}")]
        public IActionResult UpdateCustomer(int customerId, [FromBody]CustomerVM customer)
        {
            var updatedCustomer = _customersService.UpdateCustomerById(customerId, customer);
            return Ok(updatedCustomer);
        }

        [HttpDelete("DeleteCustomerById/{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
        {
            _customersService.DeleteCustomer(customerId);
            return Ok();
        }
    }
}
