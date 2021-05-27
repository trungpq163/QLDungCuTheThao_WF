using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.TaoTaiKhoan
{
    public class TaoTaiKhoanService : CrudService<ResultModel>, ITaoTaiKhoanService
    {
        public TaoTaiKhoanService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ResultModel TaoTaiKhoan(string loginName, string password, string username, string role)
        {
            return _unitOfWork.SprocQuery<ResultModel>("sp_TaoTaiKhoan", new object[] { loginName, password, username, role }).FirstOrDefault();
        }
    }
}
 