namespace QLDungCuTheThao.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Bills = new HashSet<Bill>();
        }

        public int ID { get; set; }

        public int Branch { get; set; }

        [Required]
        [StringLength(30)]
        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public int? PhoneNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string Position { get; set; }

        public int Salary { get; set; }

        public Guid rowguid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        public virtual Branch Branch1 { get; set; }
    }
}
