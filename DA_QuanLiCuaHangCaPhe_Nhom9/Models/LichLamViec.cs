using System;
using System.Collections.Generic;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Models;

public partial class LichLamViec
{
    public int MaLich { get; set; }

    public string MaNv { get; set; } = null!;

    public int MaCa { get; set; }

    public DateOnly NgayLam { get; set; }

    public string? TrangThai { get; set; }

    public virtual CaLamViec MaCaNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
