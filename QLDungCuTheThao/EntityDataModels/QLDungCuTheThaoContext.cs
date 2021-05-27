namespace QLDungCuTheThao.EntityDataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLDungCuTheThaoContext : DbContext
    {
        public QLDungCuTheThaoContext()
            : base("name=Branch1")
        {
        }

        public QLDungCuTheThaoContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .HasMany(e => e.BillDetails)
                .WithRequired(e => e.Bill1)
                .HasForeignKey(e => e.Bill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Branch1)
                .HasForeignKey(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.ProductDetails)
                .WithRequired(e => e.Branch1)
                .HasForeignKey(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Employee1)
                .HasForeignKey(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductDetails)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductCategory1)
                .HasForeignKey(e => e.ProductCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.Size)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ProductDetail>()
                .HasMany(e => e.BillDetails)
                .WithRequired(e => e.ProductDetail1)
                .HasForeignKey(e => e.ProductDetail)
                .WillCascadeOnDelete(false);
        }
    }
}
