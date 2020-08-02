namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountHolder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        Contact = c.String(maxLength: 20),
                        Address = c.String(maxLength: 200),
                        Detail = c.String(maxLength: 200),
                        BankAccountNumber = c.String(maxLength: 50),
                        AccountHolderTypeID = c.Int(nullable: false),
                        TradeMarkID = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountHolderType", t => t.AccountHolderTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Trademark", t => t.TradeMarkID, cascadeDelete: true)
                .Index(t => t.AccountHolderTypeID)
                .Index(t => t.TradeMarkID);
            
            CreateTable(
                "dbo.AccountHolderType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ledger",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Transection = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountIn = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountOut = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleId = c.Int(),
                        PurchaseId = c.Int(),
                        AccountHolderId = c.Int(nullable: false),
                        InsertionTypeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountHolder", t => t.AccountHolderId, cascadeDelete: true)
                .ForeignKey("dbo.InsertionType", t => t.InsertionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Purchase", t => t.PurchaseId, cascadeDelete: true)
                .ForeignKey("dbo.Sale", t => t.SaleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.PurchaseId)
                .Index(t => t.AccountHolderId)
                .Index(t => t.InsertionTypeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.InsertionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        PurchaseId = c.Int(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Purchase", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PurchaseId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Manufacturer = c.String(maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Availability = c.Int(nullable: false),
                        Size = c.String(maxLength: 10),
                        Brand = c.String(maxLength: 50),
                        Detail = c.String(maxLength: 100),
                        Color = c.String(maxLength: 20),
                        BarCode = c.String(maxLength: 50),
                        ImeNumber = c.String(maxLength: 50),
                        CategoryId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TradeMarkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trademark", t => t.TradeMarkId, cascadeDelete: true)
                .Index(t => t.TradeMarkId);
            
            CreateTable(
                "dbo.Trademark",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BussinessName = c.String(maxLength: 30),
                        Address = c.String(maxLength: 100),
                        Detail = c.String(maxLength: 300),
                        Contact = c.String(maxLength: 15),
                        OwnerName = c.String(maxLength: 20),
                        CreatedOn = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        Password = c.String(maxLength: 20),
                        Role = c.String(maxLength: 10),
                        TradeMarkId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trademark", t => t.TradeMarkId)
                .Index(t => t.TradeMarkId);
            
            CreateTable(
                "dbo.SoldItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SaleId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sale", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SaleId);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountHolder", "TradeMarkID", "dbo.Trademark");
            DropForeignKey("dbo.Ledger", "UserId", "dbo.User");
            DropForeignKey("dbo.Ledger", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.Ledger", "PurchaseId", "dbo.Purchase");
            DropForeignKey("dbo.PurchaseItem", "PurchaseId", "dbo.Purchase");
            DropForeignKey("dbo.PurchaseItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.SoldItems", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.SoldItems", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Category", "TradeMarkId", "dbo.Trademark");
            DropForeignKey("dbo.User", "TradeMarkId", "dbo.Trademark");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Ledger", "InsertionTypeId", "dbo.InsertionType");
            DropForeignKey("dbo.Ledger", "AccountHolderId", "dbo.AccountHolder");
            DropForeignKey("dbo.AccountHolder", "AccountHolderTypeID", "dbo.AccountHolderType");
            DropIndex("dbo.SoldItems", new[] { "SaleId" });
            DropIndex("dbo.SoldItems", new[] { "ProductId" });
            DropIndex("dbo.User", new[] { "TradeMarkId" });
            DropIndex("dbo.Category", new[] { "TradeMarkId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.PurchaseItem", new[] { "PurchaseId" });
            DropIndex("dbo.PurchaseItem", new[] { "ProductId" });
            DropIndex("dbo.Ledger", new[] { "UserId" });
            DropIndex("dbo.Ledger", new[] { "InsertionTypeId" });
            DropIndex("dbo.Ledger", new[] { "AccountHolderId" });
            DropIndex("dbo.Ledger", new[] { "PurchaseId" });
            DropIndex("dbo.Ledger", new[] { "SaleId" });
            DropIndex("dbo.AccountHolder", new[] { "TradeMarkID" });
            DropIndex("dbo.AccountHolder", new[] { "AccountHolderTypeID" });
            DropTable("dbo.Sale");
            DropTable("dbo.SoldItems");
            DropTable("dbo.User");
            DropTable("dbo.Trademark");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.PurchaseItem");
            DropTable("dbo.Purchase");
            DropTable("dbo.InsertionType");
            DropTable("dbo.Ledger");
            DropTable("dbo.AccountHolderType");
            DropTable("dbo.AccountHolder");
        }
    }
}
