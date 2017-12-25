using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carts.Controllers
{
    public class OrderController : Controller
    {
        // Get: Order
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.OrderModel.Ship postback)
        {
            if(this.ModelState.IsValid)
            {   //取得目前購物車
                var currentcart = Models.Cart.Operation.GetCurrentCart();

                //取得目前登入使用者Id
                //var userId = HttpContext.User.Identity.Name;
                var userId = HttpContext.User.Identity.GetUserId();

                using (Models.CartsEntities db = new Models.CartsEntities())
                {
                    var order = new Models.Order()
                    {
                        UserId = userId,
                        RecieverName = postback.RecieverName,
                        RecieverPhone = postback.RecieverPhone,
                        RecieverAddress = postback.RecieverAddress
                    };
                    db.Orders.Add(order);
                    db.SaveChanges();

                    // 取得購物車中OrderDetail物件
                    var orderDetails = currentcart.ToOrderDetailList(order.Id);

                    // 將其加入OrderDetails資料表後，儲存變更
                    db.OrderDetails.AddRange(orderDetails);
                    db.SaveChanges();
                }
                return Content("訂購成功");
            }
            return View();
        }

        public ActionResult MyOrder()
        {
            var userId = HttpContext.User.Identity.GetUserId();

            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                var result = (from s in db.Orders
                              where s.UserId == userId
                              select s).ToList();

                return View(result);
            }
        }

        public ActionResult MyOrderDetail(int id)
        {
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                var result = (from s in db.OrderDetails
                              where s.OrderId == id
                              select s).ToList();

                if(result.Count == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(result);
                }     
            }
        }
    }
}