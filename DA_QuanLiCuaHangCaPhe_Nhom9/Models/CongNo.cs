using System;
using System.Collections.Generic;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Models;

public partial class CongNo
{
    public int MaCongNo { get; set; }

    public int MaNcc { get; set; }

    public int MaPhieu { get; set; }

    public decimal TongTien { get; set; }

    public decimal DaTra { get; set; }

    public DateTime NgayGhiNhan { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual NhaCungCap MaNccNavigation { get; set; } = null!;

    public virtual PhieuKho MaPhieuNavigation { get; set; } = null!;

    public virtual ICollection<PhieuChi> PhieuChis { get; set; } = new List<PhieuChi>();
}
