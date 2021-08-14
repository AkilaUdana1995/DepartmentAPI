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
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
              select DepId,DepName from
               dbo.Department
              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConStr");
            SqlDataReader myReader;
            using(SqlConnection myCon=new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand=new SqlCommand(query,myCon))
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
        public JsonResult Post(Department dep)
        {
            string query = @"
              insert into  dbo.Department
              values (@DepName)
              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepName",dep.DepName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Record Posted!!");

        }



        [HttpPut]
        public JsonResult Put(Department dep)
        {
            string query = @"
              update  dbo.Department
              set DepName=@DepName
              where DepId=@DepId
              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepId", dep.DepId);
                    myCommand.Parameters.AddWithValue("@DepName", dep.DepName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Record updated!!");

        }



        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
              Delete from  dbo.Department
              where DepId=@DepId
              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepId",id);
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
