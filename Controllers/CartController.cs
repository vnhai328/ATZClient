using ATZClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATZClient.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [HttpPost]
        public ActionResult CheckOut(List<CartItem> lstProduct)
        {
            return View("CheckOut", lstProduct);
        }
    }
}