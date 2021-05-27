using QLDungCuTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.Sercurity
{
    public interface IAuthenticateService
    {
        LoginModel GetLoginInfo(string loginName);
    }
}
