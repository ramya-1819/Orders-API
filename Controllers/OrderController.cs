using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using projectAPI.Models;


namespace projectAPI.Controllers
{
    public class OrderController : ApiController
    {
        public IHttpActionResult GetAllOrders()
        {
            IList<Orders> orders = null;

            using (var x = new CO_DBEntities())
            {

                orders = x.Orders.Select(o => new Orders()
                { Pno = o.PNo, OrderDescription = o.OrderDescription, OrderDate = (DateTime)o.OrderDate, ShipDate = (DateTime)o.ShipDate, Items = o.Items, Custno = (int)o.CustNo }).ToList<Orders>();

                if (orders.Count == 0)
                    return NotFound();
                return Ok(orders);






            }
        }
        public IHttpActionResult POSTNewOrder(Orders orders)
        {

            if (!ModelState.IsValid)
                return BadRequest("entered wrong data please check again !!!!!");
            using (var x = new CO_DBEntities())
            {


                x.Orders.Add(new Order()

                {
                   // PNo = orders.Pno,
                    CustNo=orders.Custno,
                    Items= orders.Items,
                    OrderDate=orders.OrderDate,
                    ShipDate=orders.ShipDate,
                    OrderDescription=orders.OrderDescription,
                    ToCity=orders.Tocity



                }) ;
                x.SaveChanges();
            }
            return Ok();




        }

    }
}