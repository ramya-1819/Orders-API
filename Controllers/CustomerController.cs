using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using projectAPI.Models;

namespace projectAPI.Controllers
{
    public class CustomerController : ApiController
    {

        public IHttpActionResult GetAllCustomer()
        {
            IList<CustomerModel> customer = null;

            using (var x = new CO_DBEntities())
            {

                customer = x.Customers.Select(c => new CustomerModel()
                { CustNo = c.CustNo, CustName = c.CustName, Email = c.Email, Phone = c.Phone, City = c.City }).ToList<CustomerModel>();

                if (customer.Count == 0)
                    return NotFound();
                return Ok(customer);



            }
        }


        public IHttpActionResult POSTNewCustomer(CustomerModel customer)
        {

            if (!ModelState.IsValid)
                return BadRequest("entered wrong data please check again !!!!!");
            using (var x = new CO_DBEntities())
            {


                x.Customers.Add(new Customer()
                {
                    CustName = customer.CustName,
                    Email = customer.Email,
                    City = customer.City,
                    Phone = customer.Phone,
                    CustNo = customer.CustNo


                });
                x.SaveChanges();
            }
            return Ok();




        }


        public IHttpActionResult PutCustomer(CustomerModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("invalid recheck !!!");
            using (var x = new CO_DBEntities())
            {
                var existingCustomer = x.Customers.Where(c => c.CustNo == customer.CustNo).FirstOrDefault<Customer>();
                if (existingCustomer != null)

                {
                    existingCustomer.CustName = customer.CustName;
                    existingCustomer.City = customer.City;
                    existingCustomer.Phone = customer.Phone;
                    existingCustomer.Email = customer.Email;
                    x.SaveChanges();
                }
                else return NotFound();
            }
            return Ok();
        }



        public IHttpActionResult DeleteCustomer(int CustNo)
        {
            if (CustNo <= 0)
                return BadRequest("invalid customer id please enter the valid id");
            using (var x = new CO_DBEntities())
            {
                var customer = x.Customers.Where(c => c.CustNo == CustNo).FirstOrDefault();
                x.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
                x.SaveChanges();
            }
            return Ok();
        }
    }
}
