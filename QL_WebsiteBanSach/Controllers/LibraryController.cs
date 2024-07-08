using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_WebsiteBanSach.Models;

namespace QL_WebsiteBanSach.Controllers
{
    public class LibraryController : Controller
    {
        dtb_WSQLBSEntities dbo = new dtb_WSQLBSEntities();

        public ActionResult Library()
        {
            return View();
        }

        public ActionResult Library_Filter()
        {
            return View(dbo.tbl_TheLoai.ToList());
        }

		public ActionResult All_Books()
		{
			return View(dbo.tbl_Sach.ToList());
		}

		public ActionResult Catagorized_Books(string id)
        {
            return View(dbo.tbl_TacPham.Where(linq => linq.MaTheLoai == id).ToList());
        }


    }
}