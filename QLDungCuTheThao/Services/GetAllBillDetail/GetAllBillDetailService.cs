using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.GetAllBillDetail
{
    public class GetAllBillDetailService : CrudService<GetAllBillDetailModel>, IGetAllBillDetailService
    {
        public GetAllBillDetailService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public List<GetAllBillDetailModel> getAllBillDetail()
        {
            return _unitOfWork.SprocQuery<GetAllBillDetailModel>("sp_GetAllBillDetail", new object[] { }).ToList();
        }
    }
}
