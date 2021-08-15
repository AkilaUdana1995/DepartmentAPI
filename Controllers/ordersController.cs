using DepartmentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ordersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ordersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
         select dbo.Orders.orderId, dbo.Orders.orderNo, dbo.Orders.FinalValue, dbo.Orders.CustId
         from dbo.Orders
         INNER JOIN dbo.CustomerDetails on dbo.Orders.CustId=dbo.CustomerDetails.CustId
              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);

        }



        [HttpPost]
        public JsonResult post(Order odr )
        {
            string query = @"

              insert into  dbo.Orders
              values (@orderNo,@CustId,@FinalValue)
              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@orderNo",odr.orderNo);
                    myCommand.Parameters.AddWithValue("@CustId", odr.CustId);
                    myCommand.Parameters.AddWithValue("@FinalValue", 125); //here we need to pass oder.FinalValue From Front end, then it need to implement here
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Posted Successfully!!");

        }

    }
}
