using CustomerPost.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;

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


        public IActionResult CustomerPost([FromBody] Customer customer)
        {
            var currentUser = GetCurrentUser();
            _conn.Open();
            SqlCommand cmd = new SqlCommand($"insert into Customers(CustomerID,CompanyName) values('{customer.CustomerId}','{customer.CompanyName}')", _conn);
            var row = cmd.ExecuteNonQuery();
            _conn.Close();
            return Ok();
        }
        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    UserName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
                };
            }
            return null;
        }
        //httphet yap Customer için




    }
}

