using DATA.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.DBFactory
{
    public class BmsDbContext : DbContext
    {
        public BmsDbContext() : base("constring")
        { }
        public DbSet<Trademark> Trademark { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<AccountHolderType> AccountHolderType { get; set; }
        public DbSet<AccountHolder> AccountHolder { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SoldItems> SoldItem { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<PurchaseItem> PurchaseItem { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Ledger> ledger { get; set; }
        public DbSet<InsertionType> InsertionType { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tell Code First to ignore PluralizingTableName convention
            // If you keep this convention then the generated tables will have pluralized names.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Disable the default cascade behaviour of entity framework
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Category>().HasRequired(x => x.Trademark).WithMany(x => x.Category).HasForeignKey(x => x.TradeMarkId).WillCascadeOnDelete(true);
            modelBuilder.Entity<AccountHolder>().HasRequired(x => x.Trademark).WithMany(x => x.AccountHolder).HasForeignKey(x => x.TradeMarkID).WillCascadeOnDelete(true);
            modelBuilder.Entity<AccountHolder>().HasRequired(x => x.AccountHolderType).WithMany(x => x.AccountHolder).HasForeignKey(x => x.AccountHolderTypeID).WillCascadeOnDelete(true);
            modelBuilder.Entity<User>().HasRequired(x => x.Trademark).WithMany(x => x.User).HasForeignKey(x => x.TradeMarkId).WillCascadeOnDelete(false);
            modelBuilder.Entity<SoldItems>().HasRequired(x => x.Product).WithMany(x => x.SoldItems).HasForeignKey(x => x.ProductId).WillCascadeOnDelete(true);
            modelBuilder.Entity<SoldItems>().HasRequired(x => x.Sale).WithMany(x => x.SoldItems).HasForeignKey(x => x.SaleId).WillCascadeOnDelete(true);
            modelBuilder.Entity<PurchaseItem>().HasRequired(x => x.Purchase).WithMany(x => x.PurchaseItem).HasForeignKey(x => x.PurchaseId).WillCascadeOnDelete(true);
            modelBuilder.Entity<PurchaseItem>().HasRequired(x => x.Product).WithMany(x => x.PurchaseItem).HasForeignKey(x => x.ProductId).WillCascadeOnDelete(true);
            modelBuilder.Entity<Ledger>().HasRequired(x => x.AccountHolder).WithMany(x => x.Ledger).HasForeignKey(x => x.AccountHolderId).WillCascadeOnDelete(true);
            modelBuilder.Entity<Ledger>().HasRequired(x => x.User).WithMany(x => x.Ledger).HasForeignKey(x => x.UserId).WillCascadeOnDelete(true);
            modelBuilder.Entity<Ledger>().HasOptional(x => x.Sale).WithMany(x => x.Ledger).HasForeignKey(x => x.SaleId).WillCascadeOnDelete(true);
            modelBuilder.Entity<Ledger>().HasOptional(x => x.Purchase).WithMany(x => x.Ledger).HasForeignKey(x => x.PurchaseId).WillCascadeOnDelete(true);
            modelBuilder.Entity<Ledger>().HasRequired(x => x.InsertionType).WithMany(x => x.Ledger).HasForeignKey(x => x.InsertionTypeId).WillCascadeOnDelete(true);

        }
    }
}
