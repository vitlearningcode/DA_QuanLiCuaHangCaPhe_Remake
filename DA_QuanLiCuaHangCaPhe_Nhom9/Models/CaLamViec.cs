using System;
using System.Collections.Generic;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Models;

public partial class CaLamViec
{
    public int MaCa { get; set; }

    public string TenCa { get; set; } = null!;

    public TimeOnly GioBatDau { get; set; }

    public TimeOnly GioKetThuc { get; set; }

    public decimal LuongTheoCa { get; set; }

    public virtual ICollection<LichLamViec> LichLamViecs { get; set; } = new List<LichLamViec>();
}
