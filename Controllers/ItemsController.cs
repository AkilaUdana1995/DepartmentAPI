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
    public class ItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
              select ItemId,ItemCode,IemPrice,ItemNote from
               dbo.ItemCataloug
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
        public JsonResult Post(ItemCat itm)
        {
            string query = @"
              insert into  dbo.ItemCataloug
              values (@ItemCode,@IemPrice,@ItemNote)
              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ItemCode", itm.ItemCode);
                    myCommand.Parameters.AddWithValue("@IemPrice", itm.IemPrice);
                    myCommand.Parameters.AddWithValue("@ItemNote", itm.ItemNote);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Record Posted!!");

        }



        [HttpPut]
        public JsonResult Put(ItemCat itm)
        {
            string query = @"
              Update  dbo.ItemCataloug
              set ItemCode=@ItemCode,IemPrice=@IemPrice,ItemNote=@ItemNote
              Where ItemId=@ItemId
              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ItemId", itm.ItemId);
                    myCommand.Parameters.AddWithValue("@ItemCode", itm.ItemCode);
                    myCommand.Parameters.AddWithValue("@IemPrice", itm.IemPrice);
                    myCommand.Parameters.AddWithValue("@ItemNote", itm.ItemNote);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Record Updated!!");

        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
              Delete  dbo.ItemCataloug
              Where ItemId=@ItemId
              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ItemId",id);
                  
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Record Deleted!!");

        }



    }
}
