using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.ThemBill
{
    public class ThemBillService : CrudService<ResultModel>, IThemBillService
    {
        public ThemBillService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ResultModel ThemBill(int employeeId, string customer, string checkoutDate, int phoneNumber, int discount, int totalAmount, int productDetailID, int quantityOrder, int currentUnitPrice)
        {
            return _unitOfWork.SprocQuery<ResultModel>("sp_ThemBill", new object[] { employeeId, customer, checkoutDate, phoneNumber, discount, totalAmount, productDetailID, quantityOrder, currentUnitPrice }).FirstOrDefault();
        }
    }
}
