//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_WebsiteBanSach.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_ChiTietGioHang
    {
        public string MaGioHang { get; set; }
        public string MaSach { get; set; }
        public Nullable<int> SoLuong { get; set; }
    
        public virtual tbl_GioHang tbl_GioHang { get; set; }
        public virtual tbl_Sach tbl_Sach { get; set; }
    }
}
