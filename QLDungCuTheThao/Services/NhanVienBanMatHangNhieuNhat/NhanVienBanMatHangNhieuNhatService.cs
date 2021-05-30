using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.NhanVienBanMatHangNhieuNhat
{
    public class NhanVienBanMatHangNhieuNhatService : CrudService<NhanVienBanMatHangNhieuNhatModel>, INhanVienBanMatHangNhieuNhatService
    {
        public NhanVienBanMatHangNhieuNhatService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public List<NhanVienBanMatHangNhieuNhatModel> getAllNhanVienBanDuocNhieuHangNhat(string start, string end)
        {
            return _unitOfWork.SprocQuery<NhanVienBanMatHangNhieuNhatModel>("sp_NhanVien_BanMatHangNhieuNhat", new object[] { start, end }).ToList();
        }
    }
}
