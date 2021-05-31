using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.SLHangDaBanDoanhThu
{
    public class SLHangDaBanDoanhThuService : CrudService<SLHangDaBanDoanhThuModel>, ISLHangDaBanDoanhThuService
    {
        public SLHangDaBanDoanhThuService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<SLHangDaBanDoanhThuModel> GetSLHangDaBanDoanhThu(string start, string end)
        {
            return _unitOfWork.SprocQuery<SLHangDaBanDoanhThuModel>("sp_SL_HangDaBan_DoanhThu_Thang", new object[] { start, end }).ToList();
        }
    }
}
