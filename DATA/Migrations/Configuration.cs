namespace DATA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DATA.DBFactory.BmsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DATA.DBFactory.BmsDbContext context)
        {
            SeedAccountHolderTypes(context);
            SeedInsertionTypes(context);
        }

        private void SeedAccountHolderTypes(DATA.DBFactory.BmsDbContext context)
        {
            if (!context.AccountHolderType.Any())
            {
                context.AccountHolderType.Add(new Domains.AccountHolderType
                {
                    Name = "Vendor"
                });
                context.SaveChanges();

                context.AccountHolderType.Add(new Domains.AccountHolderType
                {
                    Name = "Buyer"
                });
                context.SaveChanges();

                context.AccountHolderType.Add(new Domains.AccountHolderType
                {
                    Name = "Employee"
                });
                context.SaveChanges();

                context.AccountHolderType.Add(new Domains.AccountHolderType
                {
                    Name = "Default"
                });
                context.SaveChanges();
            }
        }

        private void SeedInsertionTypes(DATA.DBFactory.BmsDbContext context)
        {
            if (!context.InsertionType.Any())
            {

                context.InsertionType.Add(new Domains.InsertionType
                {
                    Name = "Purchase"
                });
                context.SaveChanges();

                context.InsertionType.Add(new Domains.InsertionType
                {
                    Name = "Sale"
                });
                context.SaveChanges();

                context.InsertionType.Add(new Domains.InsertionType
                {
                    Name = "Salary"
                });
                context.SaveChanges();

                context.InsertionType.Add(new Domains.InsertionType
                {
                    Name = "Utility Bills"
                });
                context.SaveChanges();

                context.InsertionType.Add(new Domains.InsertionType
                {
                    Name = "Expense"
                });
                context.SaveChanges();

                context.InsertionType.Add(new Domains.InsertionType
                {
                    Name = "Rent"
                });
                context.SaveChanges();

                context.InsertionType.Add(new Domains.InsertionType
                {
                    Name = "Re-freshment"
                });
                context.SaveChanges();
            }
        }
    }
}
