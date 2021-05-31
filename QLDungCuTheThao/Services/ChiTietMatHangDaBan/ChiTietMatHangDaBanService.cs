using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.ChiTietMatHangDaBan
{
    public class ChiTietMatHangDaBanService : CrudService<ChiTietMatHangDaBanModel>, IChiTietMatHangDaBanService
    {
        public ChiTietMatHangDaBanService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public List<ChiTietMatHangDaBanModel> chiTietMatHangDaBan(string start, string end)
        {
            return _unitOfWork.SprocQuery<ChiTietMatHangDaBanModel>("sp_DS_ChiTiet_MatHangDaBan", new object[] { start, end }).ToList();
        }
    }
}
