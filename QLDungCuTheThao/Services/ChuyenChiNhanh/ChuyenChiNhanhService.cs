using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.ChuyenChiNhanh
{
    public class ChuyenChiNhanhService : CrudService<ResultModel>, IChuyenChiNhanhService
    {
        public ChuyenChiNhanhService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ResultModel ChuyenChiNhanh(string Branch, string ID)
        {
            return _unitOfWork.SprocQuery<ResultModel>("sp_ChuyenChiNhanh", new object[] { Branch, ID }).FirstOrDefault();
        }
    }
}
