using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTExample.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JWTExample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetCustomer(long id)
        {
            var customer = new Customer
            {
                Id = 1234,
                FirstName = "Michael",
                LastName = "Earls"
            };

            var serializedCustomer = JsonConvert.SerializeObject(customer);

            return Ok(serializedCustomer);
        }
    }
}