using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApıOrnek.Model;

namespace WebApıOrnek.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        SqlConnection _connection;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _connection = new SqlConnection(@"data source=(localdb)\mssqllocaldb;initial catalog=Northwind;integrated security=true");
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        [ActionName("Customer")]
        public List<Customer> Get()
        {

            SqlCommand cmd = new SqlCommand("Select CustomerId from Customers ", _connection);
            _connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Customer> result = new List<Customer>();
            while (dr.Read())

            {
                Customer customer = new Customer();
                customer.CustomerId = dr[0].ToString();

                result.Add(customer);
            }

            _connection.Close();
            dr.Close();
            return result;
        }



        [HttpGet]
        [ActionName("CustomerId")]
        public List<Customer> CustomerById(string customerıd)
        {
            SqlCommand cmd = new SqlCommand($"Select CustomerId from Customers where CustomerId='{customerıd}'", _connection);
            _connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Customer> result = new List<Customer>();
            while (dr.Read())
            {
                Customer customer = new Customer();
                customer.CustomerId = dr[0].ToString();
                result.Add(customer);
            }

            _connection.Close();
            return result;
        }

        [HttpGet]
        [ActionName("Employee")]

        public List<Employee> GetEmployee()
        {
            SqlCommand cmd = new SqlCommand($"select FirstName,LastName,EmployeeId from Employees", _connection);
            _connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Employee> EmployeeList = new List<Employee>();
            while (dr.Read())
            {
                Employee employee = new Employee();
                employee.FirstName = dr[0].ToString();
                employee.LastName = dr[1].ToString();
                employee.EmployeeId = Convert.ToInt32(dr[2]);
                EmployeeList.Add(employee);
            }
            _connection.Close();
            return EmployeeList;
        }


        [HttpGet]
        [ActionName("EmployeeId")]
        public List<Employee> EmployeeById(string employeeıd)
        {

            SqlCommand cmd = new SqlCommand($"select FirstName,LastName,EmployeeID from Employees where EmployeeID={employeeıd}", _connection);
            _connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Employee> EmployeeList = new List<Employee>();
            while (dr.Read())
            {
                Employee employee = new Employee();
                employee.FirstName = dr[0].ToString();
                employee.LastName = dr[1].ToString();
                employee.EmployeeId = Convert.ToInt32(dr[2]);
                EmployeeList.Add(employee);
            }

            _connection.Close();
            return EmployeeList;
        }

        [HttpGet]
        [ActionName("Shipper")]

        public List<Shipper> GetShippers()
        {
            SqlCommand cmd = new SqlCommand($"select ShipperID,CompanyName from Shippers", _connection);
            _connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Shipper> ShipperList = new List<Shipper>();
            while (dr.Read())
            {
                Shipper shipper = new Shipper();
                shipper.ShipperId = Convert.ToInt32(dr[0]);
                shipper.CompanyName = dr[1].ToString();
                ShipperList.Add(shipper);
            }
            _connection.Close();
            return ShipperList;
        }

        [HttpGet]
        [ActionName("ShipperId")]

        public List<Shipper> GetShippersById(int shipperid)
        {

            SqlCommand cmd = new SqlCommand($"Select ShipperID,CompanyName from Shippers where ShipperId={shipperid} ", _connection);
            _connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Shipper> ShipperIdList = new List<Shipper>();
            while (dr.Read())
            {
                Shipper shipper = new Shipper();
                shipper.ShipperId = Convert.ToInt32(dr[0]);
                shipper.CompanyName = dr[1].ToString();
                ShipperIdList.Add(shipper);
            }
            _connection.Close();
            return ShipperIdList;
        }

        [HttpGet]
        [ActionName("Product")]
        public List<Product> GetProducts()
        {
            SqlCommand cmd = new SqlCommand($"Select ProductId,ProductName from Products", _connection);
            _connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Product> productsList = new List<Product>();
            while (dr.Read())
            {
                Product product = new Product();
                product.ProductId = Convert.ToInt32(dr[0]);
                product.ProductName = dr[1].ToString();
                productsList.Add(product);
            }
            _connection.Close();
            return productsList;
        }
        [HttpGet]
        [ActionName("ProductId")]
        public List<Product> GetByProductId(int productid)
        {
            SqlCommand cmd = new SqlCommand($"Select ProductId,ProductName from Products where ProductId={productid}", _connection);
            _connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Product> productsList = new List<Product>();
            while (dr.Read())
            {
                Product product = new Product();
                product.ProductId = Convert.ToInt32(dr[0]);
                product.ProductName = dr[1].ToString();
                productsList.Add(product);
            }
            _connection.Close();
            return productsList;
        }
        [HttpPost]
        [ActionName("Order")]
        public int SaveOrder(OrderRequest orderRequest)
        {
            SqlCommand cmd = new SqlCommand($"insert into Orders (CustomerID,EmployeeID,ShipVia) values ('Mhmet',1,1))", _connection);
            _connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

            }

        }

    }

}