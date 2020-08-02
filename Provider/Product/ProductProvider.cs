using DATA.DBFactory;
using DATA.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Product
{
    public class ProductProvider
    {
        public List<DATA.Domains.Product> Get(int trademarkId)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var products = context.Product.Include("Category").Where(x => x.Category.TradeMarkId == trademarkId && !x.IsDeleted).ToList();

                return products;
            }
        }
        public DATA.Domains.Product GetById(int id)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var product = context.Product.Where(x => x.Id == id).FirstOrDefault();
                return product;
            }
        }
        public int Add(DATA.Domains.Product product)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var productToAdd = context.Product.Add(product);
                context.SaveChanges();

                return productToAdd.Id;
            }
        }


        public void SaveCategory(DATA.Domains.Category category)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var validate = context.Category.Where(name => name.Name == category.Name).FirstOrDefault();
                if (validate == null)
                {
                    context.Category.Add(category);
                    context.SaveChanges();
                }
            }
        }

        public List<DATA.Domains.Category> GetCategorybyTrademarkId(int TrademarkId)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                return context.Category.Where(x => x.TradeMarkId == TrademarkId).ToList();
            }

        }
        public void Update(DATA.Domains.Product product)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var productToupdate = context.Product.Where(x => x.Id == product.Id).FirstOrDefault();

                productToupdate.Name = product.Name;
                productToupdate.Availability = product.Availability;
                productToupdate.BarCode = product.BarCode;
                productToupdate.Brand = product.Brand;
                productToupdate.Detail = product.Detail;
                productToupdate.Color = product.Color;
                productToupdate.Size = product.Size;
                productToupdate.Cost = product.Cost;
                productToupdate.Price = product.Price;
                productToupdate.ImeNumber = product.ImeNumber;
                productToupdate.IsActive = product.IsActive;
                productToupdate.IsDeleted = product.IsDeleted;
                context.SaveChanges();
            }
        }
        public DATA.Domains.Product EditProduct(int Id)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var product = context.Product.Where(x => x.Id == Id && !x.IsDeleted).FirstOrDefault();

                return product;
            }
        }

        public void Delete(int id)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var deleteproduct = context.Product.Where(x => x.Id == id).FirstOrDefault();
                deleteproduct.IsDeleted = true;
                context.SaveChanges();
            }
        }

        public void SavePurchaseItems(List<DATA.Domains.PurchaseItem> products)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                context.PurchaseItem.AddRange(products);
                context.SaveChanges();
            }
        }

        public Purchase GeneratePurchase()
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var purchaase = context.Purchase.Add(new Purchase { CreatedOn = DateTime.UtcNow.ToLocalTime() });
                context.SaveChanges();

                return purchaase;
            }
        }

        public Sale GenerateSale()
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var sale = context.Sale.Add(new Sale { CreatedOn = DateTime.UtcNow.ToLocalTime() });
                context.SaveChanges();

                return sale;
            }
        }

        public void SaveSoldItems(List<SoldItems> soldproducts)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                context.SoldItem.AddRange(soldproducts);
                context.SaveChanges();
            }
        }

        public List<DATA.Domains.AccountHolder> getaccountholders()
        {
            using (BmsDbContext context = new BmsDbContext())
            {

                return context.AccountHolder.ToList();
            }
        }

        public List<DATA.Domains.InsertionType> getInsertionType()
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                return context.InsertionType.ToList();
            }
        }

        public DATA.Domains.AccountHolder gettrademarakaccountholder(int id)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var trademark = context.Trademark.Where(x => x.Id == id).FirstOrDefault();
                var accountholder = context.AccountHolder.Where(y => y.TradeMarkUniqueKey == trademark.UniqueKey).FirstOrDefault();

                return accountholder;
            }
        }

    }
}

