using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carts.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCart()
        {
            return PartialView("_CartPartial");
        }

        public ActionResult AddToCart(int id)
        {
            var currentCart = Models.Cart.Operation.GetCurrentCart();
            currentCart.AddProject(id);
            return PartialView("_CartPartial");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var currentCart = Models.Cart.Operation.GetCurrentCart();
            currentCart.RemoveProduct(id);
            return PartialView("_CartPartial");
        }

        public ActionResult ClearCart()
        {
            var currentCart = Models.Cart.Operation.GetCurrentCart();
            currentCart.ClearCart();
            return PartialView("_CartPartial");
        }
    }
}