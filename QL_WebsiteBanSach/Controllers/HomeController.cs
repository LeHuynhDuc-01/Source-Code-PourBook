using QL_WebsiteBanSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QL_WebsiteBanSach.Controllers
{
    public class HomeController : Controller
    {
		dtb_WSQLBSEntities dbo = new dtb_WSQLBSEntities();

		public ActionResult Index()
        {
            return View();
        }
        
		public ActionResult Website_Features()
		{
			return View();
		}

		public ActionResult Featured_Catagories()
		{
			return View(dbo.tbl_TheLoai.Where(linq => linq.tbl_TacPham.Count != 0).ToList().Take(8));
		}

		public ActionResult Featured_Books()
		{
			return View(dbo.tbl_ChiTietSach.ToList().GetRange(28, 12));
		}
	}
}