namespace QLDungCuTheThao.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillDetail")]
    public partial class BillDetail
    {
        public int ID { get; set; }

        public int Bill { get; set; }

        public int ProductDetail { get; set; }

        public int Quantity { get; set; }

        public int CurrentUnitPrice { get; set; }

        public Guid rowguid { get; set; }

        public virtual Bill Bill1 { get; set; }

        public virtual ProductDetail ProductDetail1 { get; set; }
    }
}
