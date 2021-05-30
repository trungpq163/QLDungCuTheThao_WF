using QLDungCuTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.NhanVienKhongBanDuocHang
{
    public interface INhanVienKhongBanDuocHangService
    {
        List<NhanVienKhongBanDuocHangModel> getAllNhanVienKhongBanDuocHang(string start, string end);
    }
}
