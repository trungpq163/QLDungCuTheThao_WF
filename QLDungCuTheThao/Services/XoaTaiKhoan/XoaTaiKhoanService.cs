using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.XoaTaiKhoan
{
    public class XoaTaiKhoanService : CrudService<ResultModel>, IXoaTaiKhoanService
    {
        public XoaTaiKhoanService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ResultModel XoaTaiKhoan(string loginName, string id)
        {
            return _unitOfWork.SprocQuery<ResultModel>("sp_XoaTaiKhoan", new object[] { loginName, id }).FirstOrDefault();
        }
    }
}
