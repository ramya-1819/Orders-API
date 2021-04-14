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

        public void CreateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustName", customer.CustName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@City", customer.City);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustNo", customer.CustNo);

                cmd.Parameters.AddWithValue("@CustName", customer.CustName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@City", customer.City);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        public Customer GetCustomerByID(int? Custno)

        {
            var customer = new Customer();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetCustomerbyId", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CutNo", Custno);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    customer.CustNo = Convert.ToInt32(r["custno"].ToString());
                    customer.CustName = r["custname"].ToString();
                    customer.Email = r["email"].ToString();
                    customer.City = r["city"].ToString();
                    customer.Phone = r["phone"].ToString();
                }
                con.Close();

            }
            return customer;
        }

    }
  
}