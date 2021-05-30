using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.XoaSanPham
{
    public class XoaSanPhamService : CrudService<ResultModel>, IXoaSanPhamService
    {
        public XoaSanPhamService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ResultModel XoaSanPham(int id)
        {
            return _unitOfWork.SprocQuery<ResultModel>("sp_XoaSP", new object[] { id }).FirstOrDefault();
        }
    }
}
