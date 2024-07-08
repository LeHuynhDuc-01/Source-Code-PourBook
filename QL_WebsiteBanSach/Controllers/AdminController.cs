using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_WebsiteBanSach.Models;

namespace QL_WebsiteBanSach.Controllers
{
    public class AdminController : Controller
    {
        dtb_WSQLBSEntities dbo = new dtb_WSQLBSEntities();

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Manage_Books()
        {
            ViewBag.TheLoai = dbo.tbl_TheLoai.ToList();
            ViewBag.NhaXuatBan = dbo.tbl_NhaXuatBan.ToList();
			ViewBag.TacGia = dbo.tbl_TacGia.ToList();
            return View(dbo.tbl_Sach.ToList());
        }

        public ActionResult Change_Books(FormCollection form)
        {
            tbl_Sach sach = new tbl_Sach();
            tbl_ChiTietSach ctsach = new tbl_ChiTietSach();
            tbl_TacPham tacpham = new tbl_TacPham();

			if (string.IsNullOrEmpty(form["MaSach"]))
			{
				//ctsach.TenSach = form["TenSach"];
				//ctsach.MoTa = form["MoTa"];
				//ctsach.GiaBan = int.Parse(form["GiaBan"]);
				//sach.MaTacGia = form["MaTacGia"];
				//sach.MaNhaXuatBan = form["MaNhaXuatBan"];
				//tacpham.MaTheLoai = form["MaTheLoai"];

				//dbo.tbl_Sach.Add(sach);
				//string id = dbo.tbl_Sach.ToList().LastOrDefault().MaSach;
				//ctsach.MaSach = dbo.tbl_Sach.Where(linq => linq.MaSach == id).First().MaSach;
				//tacpham.MaSach = dbo.tbl_Sach.Where(linq => linq.MaSach == id).First().MaSach;
				//ctsach.AnhBia = ctsach.MaSach + ".jpg";

				//dbo.tbl_ChiTietSach.Add(ctsach);
				//dbo.tbl_TacPham.Add(tacpham);
			}
			else if (string.IsNullOrEmpty(form["TenSach"]))
			{
				string id = form["MaSach"];
				sach = dbo.tbl_Sach.Where(linq => linq.MaSach == id).First();
				List<tbl_TacPham> list_tacpham = dbo.tbl_TacPham.Where(linq => linq.MaSach == id).ToList();
				ctsach = dbo.tbl_ChiTietSach.Where(linq => linq.MaSach == id).First();

				dbo.tbl_ChiTietSach.Remove(ctsach);
				foreach (tbl_TacPham tp in list_tacpham) dbo.tbl_TacPham.Remove(tp);
				dbo.tbl_Sach.Remove(sach);
			}
			else
			{
				//sach.MaSach = ctsach.MaSach = tacpham.MaSach = form["MaSach"];
				//ctsach.TenSach = form["TenSach"];
				//ctsach.MoTa = form["MoTa"];
				//ctsach.GiaBan = int.Parse(form["GiaBan"]);
				//sach.MaTacGia = form["MaTacGia"];
				//sach.MaNhaXuatBan = form["MaNhaXuatBan"];
				//tacpham.MaTheLoai = form["MaTheLoai"];
				//ctsach.AnhBia = ctsach.MaSach + ".jpg";

				//dbo.tbl_Sach.AddOrUpdate(sach);
				//dbo.tbl_ChiTietSach.AddOrUpdate(ctsach);
				//dbo.tbl_TacPham.AddOrUpdate(tacpham);
			}

			dbo.SaveChanges();

			return RedirectToAction("Manage_Books", "Admin");
		}

		public ActionResult Manage_Types()
        {
            return View(dbo.tbl_TheLoai.ToList());
        }

		public ActionResult Change_Types(FormCollection form)
		{
			string id = form["MaTheLoai"];
			tbl_TheLoai theloai = dbo.tbl_TheLoai.SingleOrDefault(linq => linq.MaTheLoai == id);
			if(theloai != null)
			{
				if (string.IsNullOrEmpty(form["TenTheLoai"])) dbo.tbl_TheLoai.Remove(theloai);
				else
				{
					theloai.TenTheLoai = form["TenTheLoai"];
					dbo.tbl_TheLoai.AddOrUpdate(theloai);
				}
			}
			else
			{
				theloai = new tbl_TheLoai();
				theloai.MaTheLoai = id;
				theloai.TenTheLoai = form["TenTheLoai"];
				dbo.tbl_TheLoai.Add(theloai);
			}

			try
			{
				dbo.SaveChanges();
			}
			catch
			{

			}
			return RedirectToAction("Manage_Types", "Admin");
		}

		public ActionResult Manage_Authors()
		{
			return View(dbo.tbl_TacGia.ToList());
		}

		public ActionResult Change_Authors(FormCollection form)
		{
			string id = form["MaTacGia"];
			tbl_TacGia tacgia = dbo.tbl_TacGia.SingleOrDefault(linq => linq.MaTacGia == id);
			if (tacgia != null)
			{
				if (string.IsNullOrEmpty(form["TenTacGia"])) dbo.tbl_TacGia.Remove(tacgia);
				else
				{
					tacgia.TenTacGia = form["TenTacGia"];
					tacgia.MoTa = form["MoTa"];
					dbo.tbl_TacGia.AddOrUpdate(tacgia);
				}
			}
			else
			{
				tacgia = new tbl_TacGia();
				tacgia.MaTacGia = id;
				tacgia.TenTacGia = form["TenTacGia"];
				tacgia.MoTa = form["MoTa"];
				dbo.tbl_TacGia.Add(tacgia);
			}

			try
			{
				dbo.SaveChanges();
			}
			catch
			{

			}
			return RedirectToAction("Manage_Authors", "Admin");
		}

		public ActionResult Manage_Publishers()
		{
			return View(dbo.tbl_NhaXuatBan.ToList());
		}

		public ActionResult Change_Publishers(FormCollection form)
		{
			string id = form["MaNhaXuatBan"];
			tbl_NhaXuatBan nxb = dbo.tbl_NhaXuatBan.SingleOrDefault(linq => linq.MaNhaXuatBan == id);
			if (nxb != null)
			{
				if (string.IsNullOrEmpty(form["TenNhaXuatBan"])) dbo.tbl_NhaXuatBan.Remove(nxb);
				else
				{
					nxb.TenNhaXuatBan = form["TenNhaXuatBan"];
					nxb.MoTa = form["MoTa"];
					dbo.tbl_NhaXuatBan.AddOrUpdate(nxb);
				}
			}
			else
			{
				nxb = new tbl_NhaXuatBan();
				nxb.MaNhaXuatBan = id;
				nxb.TenNhaXuatBan = form["TenNhaXuatBan"];
				nxb.MoTa = form["MoTa"];
				dbo.tbl_NhaXuatBan.Add(nxb);
			}

			try
			{
				dbo.SaveChanges();
			}
			catch
			{

			}
			return RedirectToAction("Manage_Publishers", "Admin");
		}

		public ActionResult Manage_Customers()
        {
            return View(dbo.tbl_KhachHang.ToList());
        }

		public ActionResult Manage_Employees()
        {
            return View(dbo.tbl_NhanVien.ToList());
        }
	}
}