using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA.DBFactory;
using DATA.Domains;

namespace Provider.TradeMark
{
    public class TrademarkProvider
    {
        public int Add(Trademark trademark)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var TradeMarkToAdd = context.Trademark.Add(trademark);
                context.SaveChanges();
                return TradeMarkToAdd.Id;
            }
        }

        public List<Trademark> Get()
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                return context.Trademark.ToList();
            }
        }

        public DATA.Domains.Trademark GetById(int id)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var getTradeMark = context.Trademark.Where(x => x.Id == id).FirstOrDefault();
                return getTradeMark;
            }
        }

        public void Update(DATA.Domains.Trademark trademark)
        {
            using(BmsDbContext context= new BmsDbContext())
            {
                var tradeMarktoaupdate = context.Trademark.Where(x => x.Id == trademark.Id).FirstOrDefault();

                tradeMarktoaupdate.BussinessName = trademark.BussinessName;
                tradeMarktoaupdate.OwnerName = trademark.OwnerName;
                tradeMarktoaupdate.Contact = trademark.Contact;
                tradeMarktoaupdate.Address = trademark.Address;
                tradeMarktoaupdate.Detail = trademark.Detail;
                context.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var tradeMarkToDelete = context.Trademark.Where(x => x.Id == id).FirstOrDefault();

                tradeMarkToDelete.IsDeleted = true;

                context.SaveChanges();

                return tradeMarkToDelete.Id;
            }
        }

        public List<AccountHolderType> GetAccountHolderType()
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                return context.AccountHolderType.ToList();
            }
        }
    }
}
