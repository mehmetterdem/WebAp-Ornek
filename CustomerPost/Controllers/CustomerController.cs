using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CustomerPost.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        SqlConnection _conn;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
            _conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;initial catalog=Northwind;integrated security=true");
        }

        [HttpPost]

        public IActionResult CustomerPost([FromBody] Customer customer)
        {

            _conn.Open();
            SqlCommand cmd = new SqlCommand($"insert into Customers(CustomerID,CompanyName) values('{customer.CustomerId}','{customer.CompanyName}')", _conn);
            var row = cmd.ExecuteNonQuery();
            _conn.Close();
            return Ok();
        }

        [HttpGet]

        public List<Customer> GetCustomers()
        {

        }


    }
}

