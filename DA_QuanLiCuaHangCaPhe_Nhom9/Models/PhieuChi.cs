using System;
using System.Collections.Generic;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Models;

public partial class PhieuChi
{
    public int MaPhieuChi { get; set; }

    public DateTime NgayChi { get; set; }

    public string LoaiChi { get; set; } = null!;

    public decimal SoTien { get; set; }

    public string HinhThuc { get; set; } = null!;

    public string? GhiChu { get; set; }

    public int? MaPhieu { get; set; }

    public int? MaCongNo { get; set; }

    public int MaNv { get; set; }

    public virtual CongNo? MaCongNoNavigation { get; set; }

    public virtual PhieuKho? MaPhieuNavigation { get; set; }
}
