using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.XemTatCaSP
{
    public class XemTatCaSPService : CrudService<XemTatCaSPModel>, IXemTatCaSPService
    {
        public XemTatCaSPService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<XemTatCaSPModel> TatCaSP()
        {
            return _unitOfWork.SprocQuery<XemTatCaSPModel>("sp_XemTatCaSP", new object[] { }).ToList();
        }
    }
}
