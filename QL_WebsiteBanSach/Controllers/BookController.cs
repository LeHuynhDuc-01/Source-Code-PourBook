using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_WebsiteBanSach.Models;

namespace QL_WebsiteBanSach.Controllers
{
    public class BookController : Controller
    {
        dtb_WSQLBSEntities dbo = new dtb_WSQLBSEntities();

        public ActionResult Book_Card(string id)
        {
            return View(dbo.tbl_Sach.FirstOrDefault(linq => linq.MaSach == id));
        }

        public ActionResult Book_Details(string id)
        {
			return View(dbo.tbl_Sach.FirstOrDefault(linq => linq.MaSach == id));
		}

        public ActionResult Book_Card_More(string id)
        {
			return View(dbo.tbl_Sach.FirstOrDefault(linq => linq.MaSach == id));
		}

        public ActionResult Suggested_Books()
        {
            return View(dbo.tbl_ChiTietSach.ToList().GetRange(20, 12));
        }

		public ActionResult Searched_Books(string search)
		{
            var list_chitietsach = dbo.tbl_ChiTietSach.Where(linq => linq.TenSach.Contains(search)).ToList();
            ViewBag.Count = list_chitietsach.Count;
			return View(list_chitietsach);
		}
	}
}