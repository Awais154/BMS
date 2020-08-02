using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Provider.Product;
using DATA.Domains;
using Provider.Ledger;

namespace Dashboard.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ProductProvider productprovider;
        private readonly LedgerProvider ledgerProvider;
        public ProductController()
        {
            productprovider = new ProductProvider();
            ledgerProvider = new LedgerProvider();
        }


        #region Product
        public ActionResult AddProduct()
        {
            var category = productprovider.GetCategorybyTrademarkId(1);
            TempData["Categories"] = category;

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                DATA.Domains.Product product = new DATA.Domains.Product
                {
                    Availability = model.Availability,
                    BarCode = model.BarCode,
                    Brand = model.Brand,
                    Color = model.Color,
                    Detail = model.Detail,
                    CreatedOn = DateTime.Now,
                    CategoryId = model.CategoryId,
                    ImeNumber = model.ImeNumber,
                    Name = model.Name,
                    Price = model.Price,
                    Size = model.Size,
                    Cost = model.Cost
                };
                productprovider.Add(product);
            }
            var category = productprovider.GetCategorybyTrademarkId(1);
            TempData["Categories"] = category;

            return View();
        }

        [HttpPost]
        public ActionResult SaveCategory(string categoryname)
        {
            DATA.Domains.Category category = new DATA.Domains.Category
            {
                Name = categoryname,
                TradeMarkId = 1
            };
            productprovider.SaveCategory(category);
            return RedirectToAction("AddProduct");
        }

        public ActionResult GetProduct()
        {
            var productlist = productprovider.Get(1);

            return View(productlist);
        }

        public ActionResult Edit(int id)
        {
            var product = productprovider.EditProduct(id);
            return View("edit", product);
        }

        [HttpPost]
        public ActionResult Update(DATA.Domains.Product product)
        {
            productprovider.Update(product);
            return RedirectToAction("getproduct");
        }

        public ActionResult Delete(int id)
        {
            productprovider.Delete(id);
            return RedirectToAction("GetProduct");
        }

        public ActionResult SavePrintInvoice()
        {
            var purchaseInvoice = GetPurshaseInvoice();



            return View(purchaseInvoice);
        }

        #endregion

        #region Sale

        public ActionResult GetProductToSale()
        {
            var productlist = productprovider.Get(1);

            return View(productlist);
        }
        [HttpPost]
        public ActionResult AddProductToSaleInvoice(Models.Saledto saleproduct)
        {

            var product = productprovider.GetById(saleproduct.ProductId);
            SoldItems soldItems = new SoldItems
            {
                ProductId = product.Id,
                UnitPrice = saleproduct.UnitPrice,
                Quantity = saleproduct.Quantity
            };

            List<SoldItems> soldproductlist = new List<SoldItems>();
            var soldproducts = Session["soldproductlist"] as List<SoldItems>;
            if (soldproducts == null)
            {
                soldproductlist.Add(soldItems);
                Session["soldproductlist"] = soldproductlist;
            }
            else
            {
                soldproducts.Add(soldItems);
                Session["soldproductlist"] = soldproducts;
            }
            return RedirectToAction("GetProductToSale");
        }

        public ActionResult ShowSaleInvoice()
        {
            try
            {
                var accountholder = productprovider.getaccountholders();
                TempData["AccountHolder"] = accountholder;

                var insertiontype = productprovider.getInsertionType();
                TempData["InsertionType"] = insertiontype;

                var saleInvoice = GetSaleInvoice();

                return View(saleInvoice);
            }
            catch (Exception ex)
            {
                return View("Views/Product/Error.cshtml", ex.Message);
            }
        }
        [HttpPost]
        public ActionResult SaveSaleInvoice(AmountModel model)
        {
            try
            {
                var product = Session["soldproductlist"] as List<SoldItems>;

                var UserInfo = (Dashboard.Models.UserInfo)Session["UserInfo"];

                var sale = productprovider.GenerateSale();
                product.ForEach(x => x.SaleId = sale.Id);
                product.ForEach(x => x.CreatedOn = DateTime.Now);

                productprovider.SaveSoldItems(product);

                var ledgerForBuyer = BuildSaleLedger(sale.Id, model.InsertionTypeId, UserInfo.UserId, model.AmountIn, model.AmountOut, model.Balance, model.Total, model.AccountHolderId);
                ledgerProvider.SaveLedger(ledgerForBuyer);

                var trademarkaccountholder = productprovider.gettrademarakaccountholder(UserInfo.TrademarkID);

                var ledgerFortradeMark = BuildSaleLedger(sale.Id, model.InsertionTypeId, UserInfo.UserId, model.AmountOut, model.AmountIn, -model.Balance, model.Total, trademarkaccountholder.Id);
                ledgerProvider.SaveLedger(ledgerFortradeMark);
                Session["productlist"] = null;
                return RedirectToAction("ShowPurchaseInvoice");
            }

            catch (Exception ex)
            {
                return View("Views/Product/Error.cshtml", ex.Message);
            }
        }
        #endregion

        #region Purchase
        public ActionResult GetProductToPurchase()
        {
            var productlist = productprovider.Get(1);
            return View(productlist);
        }

        [HttpPost]
        public ActionResult AddProductsToPurchaseInvoice(Models.purchaseDto productDto)
        {
            var product = productprovider.GetById(productDto.ProductId);
            PurchaseItem purchaseItem = new PurchaseItem
            {
                ProductId = product.Id,
                PurchasePrice = productDto.PurchasePrice,
                Quantity = productDto.Quantity
            };

            List<DATA.Domains.PurchaseItem> productList = new List<DATA.Domains.PurchaseItem>();
            var products = Session["productlist"] as List<DATA.Domains.PurchaseItem>;

            if (products == null)
            {
                productList.Add(purchaseItem);
                Session["productlist"] = productList;
            }
            else
            {
                products.Add(purchaseItem);
                Session["productlist"] = products;
            }

            return RedirectToAction("GetProductToPurchase");
        }

        public ActionResult RemoveProductPurchaseInvoice(int productId)
        {
            var products = Session["productlist"] as List<DATA.Domains.PurchaseItem>;
            var producttoremove = products.Where(x => x.ProductId == productId).FirstOrDefault();

            products.Remove(producttoremove);

            Session["productlist"] = products;

            return RedirectToAction("ShowPurchaseInvoice");
        }

        public ActionResult ShowPurchaseInvoice(int purchaseID)
        {
            try
            {
                var acountholder = productprovider.getaccountholders();
                TempData["AccountHolder"] = acountholder;

                var insertiontype = productprovider.getInsertionType();
                TempData["InsertionType"] = insertiontype;

                var Buyerledger = ledgerProvider.GetLedgerByPurchaseId(purchaseID);
                TempData["ledger"] = Buyerledger;

                var purchaseInvoice = GetPurshaseInvoice();

                return View(purchaseInvoice);
            }
            catch (Exception ex)
            {
                return View("Views/Product/Error.cshtml", ex.Message);
            }
        }

        [HttpPost]
        public ActionResult SavePurchaseInvoice(AmountModel model)
        {
            try
            {
                var products = Session["productlist"] as List<DATA.Domains.PurchaseItem>;

                var UserInfo = (Dashboard.Models.UserInfo)Session["UserInfo"];

                var purchase = productprovider.GeneratePurchase();

                products.ForEach(x => x.PurchaseId = purchase.Id);
                products.ForEach(x => x.CreatedOn = DateTime.Now);

                productprovider.SavePurchaseItems(products);

                var ledgerForBuyer = BuildLedger(purchase.Id, model.InsertionTypeId, UserInfo.UserId, model.AmountIn, model.AmountOut, model.Balance, model.Total, model.AccountHolderId);
                ledgerProvider.SaveLedger(ledgerForBuyer);

                var trademarkaccountholder = productprovider.gettrademarakaccountholder(UserInfo.TrademarkID);

                var ledgerFortradeMark = BuildLedger(purchase.Id, model.InsertionTypeId, UserInfo.UserId, model.AmountOut, model.AmountIn, -model.Balance, model.Total, trademarkaccountholder.Id);
                ledgerProvider.SaveLedger(ledgerFortradeMark);

                var Buyerledger = ledgerProvider.GetLedgerByPurchaseId(purchase.Id);
                TempData["ledger"] = Buyerledger;

                Session["productlist"] = null;

                return RedirectToAction("ShowPurchaseInvoice");
            }
            catch (Exception ex)
            {
                return View("Views/Product/Error.cshtml", ex.Message);
            }
        }

        #endregion

        #region private

        private List<Dashboard.Models.ProductsModel> GetPurshaseInvoice()
        {
            var products = Session["productlist"] as List<DATA.Domains.PurchaseItem>;

            List<Dashboard.Models.ProductsModel> mapedlist = new List<ProductsModel>();
            products.ForEach(x =>
            {
                var product = productprovider.GetById(x.ProductId);
                ProductsModel model = new ProductsModel
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = x.Quantity,
                    Size = product.Size,
                    Color = product.Color,
                    Brand = product.Brand,
                    ImeNumber = product.ImeNumber,
                    Detail = product.Detail,
                    ProductId = product.Id,
                    Cost = product.Cost
                };
                mapedlist.Add(model);
            });

            return mapedlist;
        }

        private List<ProductsModel> GetSaleInvoice()
        {
            var productsToSale = Session["soldproductlist"] as List<SoldItems>;
            List<ProductsModel> maplist = new List<ProductsModel>();
            productsToSale.ForEach(x =>
            {
                var product = productprovider.GetById(x.ProductId);
                ProductsModel model = new ProductsModel
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = x.Quantity,
                    Size = product.Size,
                    Color = product.Color,
                    Brand = product.Brand,
                    ImeNumber = product.ImeNumber,
                    Detail = product.Detail,
                    ProductId = product.Id
                };
                maplist.Add(model);
            });

            return maplist;
        }

        private DATA.Domains.Ledger BuildLedger(int purchaseId, int insertiontypeid, int userid, decimal amountIn, decimal amountOut, decimal balance, decimal total, int accountHolderid)
        {
            Ledger ledger = new Ledger
            {
                AmountIn = amountIn,
                AmountOut = amountOut,
                Balance = balance,
                CreatedOn = DateTime.Now,
                PurchaseId = purchaseId,
                Total = total,
                Transection = "purchase",
                UserId = userid,
                AccountHolderId = accountHolderid,
                InsertionTypeId = insertiontypeid,

            };
            return ledger;
        }

        private Ledger BuildSaleLedger(int saleid, int insertiontypeid, int userid, decimal amountIn, decimal amountOut, decimal balance, decimal total, int accountHolderid)
        {
            Ledger ledger = new Ledger
            {
                AmountIn = amountIn,
                AmountOut = amountOut,
                Balance = balance,
                CreatedOn = DateTime.Now,
                SaleId = saleid,
                Total = total,
                Transection = "Done With Sale",
                UserId = userid,
                AccountHolderId = accountHolderid,
                InsertionTypeId = insertiontypeid
            };

            return ledger;
        }
        #endregion
    }
}


