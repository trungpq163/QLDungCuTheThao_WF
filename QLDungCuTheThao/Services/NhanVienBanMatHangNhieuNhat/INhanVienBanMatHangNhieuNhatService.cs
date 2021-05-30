using QLDungCuTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.NhanVienBanMatHangNhieuNhat
{
    public interface INhanVienBanMatHangNhieuNhatService
    {
        List<NhanVienBanMatHangNhieuNhatModel> getAllNhanVienBanDuocNhieuHangNhat(string start, string end);
    }
}
