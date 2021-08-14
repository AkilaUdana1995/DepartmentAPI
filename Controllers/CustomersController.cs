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
    public class CustomersController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public CustomersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
              select CustId,CustName,CAddress1,CAddress2,CAdress3,SubRub,CState,Postal,InvoiceNo,InvoiceDate,RefferenceNo,Notes from
               dbo.CustomerDetails
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
        public JsonResult Post(Customer cus)
        {
            string query = @"
              insert into  dbo.CustomerDetails
              values (@CustName,@CAddress1,@CAddress2,@CAdress3,@SubRub,@CState,@Postal,@InvoiceNo,@InvoiceDate,@RefferenceNo,@Notes)
              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CustName", cus.CustName);
                    myCommand.Parameters.AddWithValue("@CAddress1", cus.CAddress1);
                    myCommand.Parameters.AddWithValue("@CAddress2", cus.CAddress2);
                    myCommand.Parameters.AddWithValue("@CAdress3", cus.CAdress3);
                    myCommand.Parameters.AddWithValue("@SubRub", cus.SubRub);
                    myCommand.Parameters.AddWithValue("@CState", cus.CState);
                    myCommand.Parameters.AddWithValue("@Postal", cus.Postal);
                    myCommand.Parameters.AddWithValue("@InvoiceNo", cus.InvoiceNo);
                    myCommand.Parameters.AddWithValue("@InvoiceDate", cus.InvoiceDate);
                    myCommand.Parameters.AddWithValue("@RefferenceNo", cus.RefferenceNo);
                    myCommand.Parameters.AddWithValue("@Notes", cus.Notes);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Record Inserted!!");

        }



        [HttpPut]
        public JsonResult Put(Customer cus)
        {
            string query = @"
              update  dbo.CustomerDetails
              set CustName=@CustName,CAddress1=@CAddress1,CAddress2=@CAddress2,CAdress3=@CAdress3,SubRub=@SubRub,CState=@CState,Postal=@Postal,InvoiceNo=@InvoiceNo,InvoiceDate=@InvoiceDate,RefferenceNo=@RefferenceNo,Notes=@Notes
              where CustId=@CustId
              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                try
                {
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@CustId", cus.CustId);
                        myCommand.Parameters.AddWithValue("@CustName", cus.CustName);
                        myCommand.Parameters.AddWithValue("@CAddress1", cus.CAddress1);
                        myCommand.Parameters.AddWithValue("@CAddress2", cus.CAddress2);
                        myCommand.Parameters.AddWithValue("@CAdress3", cus.CAdress3);
                        myCommand.Parameters.AddWithValue("@SubRub", cus.SubRub);
                        myCommand.Parameters.AddWithValue("@CState", cus.CState);
                        myCommand.Parameters.AddWithValue("@Postal", cus.Postal);
                        myCommand.Parameters.AddWithValue("@InvoiceNo", cus.InvoiceNo);
                        myCommand.Parameters.AddWithValue("@InvoiceDate", cus.InvoiceDate);
                        myCommand.Parameters.AddWithValue("@RefferenceNo", cus.RefferenceNo);
                        myCommand.Parameters.AddWithValue("@Notes", cus.Notes);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();

                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return new JsonResult("Record updated!!");

        }



        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
              Delete from  dbo.CustomerDetails
              where CustId=@CustId
              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                try
                {
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@CustId", id);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();

                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return new JsonResult("Record Deleted!!");

        }

    }
}
