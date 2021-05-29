using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Models
{
    public class GetAllBillDetailModel
    {
        public int ID { get; set; }

        public string ProductDescription { get; set; }

        public string Customer { get; set; }

        public int PhoneNumber { get; set; }

        public int TotalAmount { get; set; }

        public int Quantity { get; set; }

        public int CurrentUnitPrice { get; set; }

        public string Employee { get; set; }

        public string Position { get; set; }

        public int Branch { get; set; }

        public DateTime CheckoutDate { get; set; }
    }
}
