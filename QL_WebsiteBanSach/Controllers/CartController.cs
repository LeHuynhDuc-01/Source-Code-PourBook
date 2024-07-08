using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using QL_WebsiteBanSach.Models;

namespace QL_WebsiteBanSach.Controllers
{
    public class CartController : Controller
    {
        dtb_WSQLBSEntities dbo = new dtb_WSQLBSEntities();

        public List<CartModel> Get_Cart()
        {
            List<CartModel> list_cart = Session["Cart"] as List<CartModel>;
            if (list_cart == null)
            {
				list_cart = new List<CartModel>();
                Session["Cart"] = list_cart;
            }
            return list_cart;
        }

        public ActionResult Add_Cart(string id, string url)
        {
			List<CartModel> list_cart = Get_Cart();
            CartModel cart = list_cart.Find(linq => linq.MaSach == id);
            if (cart == null)
            {
                cart = new CartModel(id);
                list_cart.Add(cart);
				Session["Cart"] = list_cart;
            }
            else
            {
                cart.SoLuong = cart.SoLuong + 1;
				Session["Cart"] = list_cart;
            }
			return Redirect(url);
		}

		public ActionResult Cart_Page()
        {
            List<CartModel> list_cart = Get_Cart();
            ViewBag.TotalMoney = Get_TotalMoney();
            ViewBag.TotalQuantity = Get_TotalQuantity();
            return View(list_cart);
        }

        public int Get_TotalMoney()
        {
            int total = 0;
            List<CartModel> list_cart = Get_Cart();
            if (list_cart != null) total = list_cart.Sum(linq => linq.ThanhTien);
            return total;
		}

        public int Get_TotalQuantity()
        {
			int total = 0;
			List<CartModel> list_cart = Get_Cart();
			if (list_cart != null) total = list_cart.Sum(linq => linq.SoLuong);
			return total;
		}

        public ActionResult Delete_Cart(string id)
        {
            List<CartModel> list_cart = Get_Cart();
			CartModel cart = list_cart.Find(linq => linq.MaSach == id);
            if (cart != null)
            {
                list_cart.Remove(cart);
                Session["Cart"] = list_cart;
            }
			return RedirectToAction("Cart_Page", "Cart");
		}

        public ActionResult Update_Cart(string id, string quantity)
        {
            List<CartModel> list_cart = Get_Cart();
            CartModel cart = list_cart.Find(linq => linq.MaSach == id);
            if (cart != null && int.Parse(quantity) > 0)
            {
				cart.SoLuong = int.Parse(quantity);
				Session["Cart"] = list_cart;
			}
			return RedirectToAction("Cart_Page", "Cart");
		}

        public ActionResult CheckOut_Page()
        {
            List<CartModel> list_cart = Get_Cart();
            return View(list_cart);
        }
    }
}