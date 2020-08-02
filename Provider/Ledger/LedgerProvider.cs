using DATA.DBFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Ledger
{
    public class LedgerProvider
    {
        public void SaveLedger(DATA.Domains.Ledger ledger)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                context.ledger.Add(ledger);
                context.SaveChanges();
            }
        }

        public List<DATA.Domains.Ledger> GetLedger(DateTime toDate, DateTime fromDate, int accounthoderId, int insertiontypeId, int trademarkId)
        {

            using (BmsDbContext context = new BmsDbContext())
            {
                var result = from trademark in context.Trademark
                             join accountHolder in context.AccountHolder on trademark.Id equals accountHolder.TradeMarkID
                             join ledger in context.ledger on accountHolder.Id equals ledger.AccountHolderId
                             where ledger.CreatedOn >= fromDate && ledger.CreatedOn <= toDate
                             select ledger;

                List<DATA.Domains.Ledger> response = new List<DATA.Domains.Ledger>();

                if (accounthoderId > 0)
                {
                    response.AddRange(result.Where(x => x.AccountHolderId == accounthoderId).ToList());
                }

                if (insertiontypeId > 0)
                {
                    response.AddRange(result.Where(x => x.InsertionTypeId == insertiontypeId).ToList());
                }

                return response;
            }
        }

        public List<DATA.Domains.Ledger> GetLedgerByPurchaseId(int purchaseId)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var ledger = context.ledger.Where(x => x.PurchaseId == purchaseId && x.AmountIn == 0).ToList();

                return ledger;
            }
        }
    }
}
