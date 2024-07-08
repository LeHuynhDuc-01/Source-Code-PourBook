using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_WebsiteBanSach.Models;

namespace QL_WebsiteBanSach.Controllers
{
    public class LayoutController : Controller
    {
        dtb_WSQLBSEntities dbo = new dtb_WSQLBSEntities();

        public ActionResult Header_MainLayoutPage()
        {
            return View();
        }

        public ActionResult Footer_MainLayoutPage()
        {
            return View();
        }

		public ActionResult Nagivation_MainLayoutPage()
		{
			return View(dbo.tbl_TheLoai.ToList());
		}

		public ActionResult Header_AdminLayoutPage()
		{
			return View();
		}

		public ActionResult Sidebar_AdminLayoutPage()
		{
			return View();
		}

		public ActionResult Footer_AdminLayoutPage()
		{
			return View();
		}
	}
}