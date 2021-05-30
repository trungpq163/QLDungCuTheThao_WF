using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.NhanVienKhongBanDuocHang
{
    public class NhanVienKhongBanDuocHangService : CrudService<NhanVienKhongBanDuocHangModel>, INhanVienKhongBanDuocHangService
    {
        public NhanVienKhongBanDuocHangService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public List<NhanVienKhongBanDuocHangModel> getAllNhanVienKhongBanDuocHang(string start, string end)
        {
            return _unitOfWork.SprocQuery<NhanVienKhongBanDuocHangModel>("sp_NhanVien_KhongBanDuocHang", new object[] { 0, start, end }).ToList();
        }
    }
}
