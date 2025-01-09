using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Backstage.Models.EFModels
{
    public partial class AppDbContext2 : DbContext
    {
        public AppDbContext2()
            : base("name=AppDbContext2")
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Employee_Role_Rel> Employee_Role_Rel { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<GroupBuying> GroupBuyings { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role_Function_Rel> Role_Function_Rel { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Wish> Wishes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EncryptedPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employee_Role_Rel)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Function>()
                .HasMany(e => e.Role_Function_Rel)
                .WithRequired(e => e.Function)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupBuying>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.GroupBuying)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupBuying>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.GroupBuying)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.EncryptedPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.ConfirmCode)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Wishes)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.GroupBuyings)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductImages)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Wishes)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Employee_Role_Rel)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasOptional(e => e.Role_Function_Rel)
                .WithRequired(e => e.Role);

            modelBuilder.Entity<Shop>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<Shop>()
                .Property(e => e.EncryptedPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Shop>()
                .Property(e => e.IdentityCard)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Shop)
                .WillCascadeOnDelete(false);
        }
    }
}
