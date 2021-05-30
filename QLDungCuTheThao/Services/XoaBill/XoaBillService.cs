using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.XoaBill
{
    public class XoaBillService : CrudService<ResultModel>, IXoaBillService
    {
        public XoaBillService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ResultModel XoaBill(int id)
        {
            return _unitOfWork.SprocQuery<ResultModel>("sp_XoaBill", new object[] { id }).FirstOrDefault();
        }
    }
}
