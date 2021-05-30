using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Models
{
    public class XemTatCaSPModel
    {
        public int ID { get; set; }

        public Nullable<int> Quantity { get; set; }

        public string Name { get; set; }

        public string ProductCategory { get; set; }

        public int Price { get; set; }

        public string Manufacturer { get; set; }
    }
}
