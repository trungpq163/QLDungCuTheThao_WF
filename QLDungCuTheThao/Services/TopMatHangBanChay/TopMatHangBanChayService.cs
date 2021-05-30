using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.TopMatHangBanChay
{
    public class TopMatHangBanChayService : CrudService<TopMatHangBanChayModel>, ITopMatHangBanChayService
    {
        public TopMatHangBanChayService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public List<TopMatHangBanChayModel> getAllMatHangBanChay(string start, string end)
        {
            return _unitOfWork.SprocQuery<TopMatHangBanChayModel>("sp_Top5_MatHang_BanChay", new object[] { start, end }).ToList();
        }
    }
}
