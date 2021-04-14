using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectAPI.Details;
using projectAPI.Models;





namespace projectAPI.Controllers
{
    public class SP_CUSTOMERController : Controller

    {
        MVC_CURD_DAL dbdetails = new MVC_CURD_DAL();

        // GET: SP_CUSTOMER
        public ActionResult Index()
        {
            List<Customer> customerList = dbdetails.GetAllCustomers().ToList();
            return View(customerList);
        }

        // GET: SP_CUSTOMER/Details/5
        public ActionResult Details(int CustNo)
        {
            if (CustNo == null) 
            {
                return HttpNotFound();
            }

            return View();
        }

        // GET: SP_CUSTOMER/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SP_CUSTOMER/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SP_CUSTOMER/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SP_CUSTOMER/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SP_CUSTOMER/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SP_CUSTOMER/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
