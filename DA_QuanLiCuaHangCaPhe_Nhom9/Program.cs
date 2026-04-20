using DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang;
using DA_QuanLiCuaHangCaPhe_Nhom9.UI.POS;

namespace DA_QuanLiCuaHangCaPhe_Nhom9
{
    internal static class Program
    {
        [System.STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Loginform());
        }
    }
}