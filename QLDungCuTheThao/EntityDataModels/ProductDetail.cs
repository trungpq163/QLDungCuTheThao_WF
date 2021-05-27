namespace QLDungCuTheThao.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductDetail")]
    public partial class ProductDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductDetail()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int ID { get; set; }

        public int Product { get; set; }

        public int Branch { get; set; }

        [StringLength(5)]
        public string Size { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductDescription { get; set; }

        public Guid rowguid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }

        public virtual Branch Branch1 { get; set; }

        public virtual Product Product1 { get; set; }
    }
}
