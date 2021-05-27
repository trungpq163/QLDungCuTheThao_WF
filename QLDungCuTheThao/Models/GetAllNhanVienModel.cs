using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Models
{
    public class GetAllNhanVienModel
    {
        public int ID { get; set; }

        public int Branch { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public int PhoneNumber { get; set; }

        public string Position { get; set; }

        public int Salary { get; set; }
    }
}
