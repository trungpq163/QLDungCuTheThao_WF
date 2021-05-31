using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.SLTonKho
{
    public class SLTonKhoService : CrudService<SLTonKhoModel>, ISLTonKhoService
    {
        public SLTonKhoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<SLTonKhoModel> GetSLTonKho()
        {
            return _unitOfWork.SprocQuery<SLTonKhoModel>("sp_SLTonKho", new object[] { }).ToList();
        }
    }
}
