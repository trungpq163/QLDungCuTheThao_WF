using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.Sercurity
{
    public class LoginService : CrudService<LoginModel>, IAuthenticateService
    {
        public LoginService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public LoginModel GetLoginInfo(string loginName)
        {
            return _unitOfWork.SprocQuery<LoginModel>("sp_GetLoginInfo", new object[] { loginName }).FirstOrDefault();
        }
    }
}
