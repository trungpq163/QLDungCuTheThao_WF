using QLDungCuTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.ThemBill
{
    public interface IThemBillService
    {
        ResultModel ThemBill(int employeeId, string customer, string checkoutDate, int phoneNumber, int discount, int totalAmount, int productDetailID, int quantityOrder, int currentUnitPrice);
    }
}
