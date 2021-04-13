using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projectAPI.Models;
using System.Data.SqlClient;
using System.Data;

namespace projectAPI.Details
{
    public class MVC_CURD_DAL
    {
        string connectionString = "Data Source = .; intial catalog=CO_DB;";
        public IEnumerable<Customer> GetAllCustomers()
        {
            var customerList = new List<Customer>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllCustomers", con);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var customer = new Customer();
                    customer.CustNo = Convert.ToInt32(r["custno"].ToString());
                    customer.CustName = r["custname"].ToString();
                    customer.Email = r["email"].ToString();
                    customer.City = r["city"].ToString();
                    customer.Phone = r["phone"].ToString();

                    customerList.Add(customer);

                }
                con.Close();
            }
            return customerList;
        }
    }
}