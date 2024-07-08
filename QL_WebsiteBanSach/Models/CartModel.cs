using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QL_WebsiteBanSach.Models
{
	public class CartModel
	{
		dtb_WSQLBSEntities dbo = new dtb_WSQLBSEntities();

		public string MaSach { get; set; }
		public string TenSach { get; set; }
		public string AnhBia { get; set; }
		public int GiaBan { get; set; }
		public int SoLuong { get; set; }

		public int ThanhTien
		{ get {  return GiaBan * SoLuong; } }

		public CartModel(string id)
		{
			tbl_ChiTietSach chitietsach = dbo.tbl_ChiTietSach.Where(linq => linq.MaSach == id).FirstOrDefault();
			if (chitietsach == null) return;
			MaSach = id;
			TenSach = chitietsach.TenSach;
			AnhBia = chitietsach.AnhBia;
			GiaBan = (int)chitietsach.GiaBan;
			SoLuong = 1;
		}
	}
}