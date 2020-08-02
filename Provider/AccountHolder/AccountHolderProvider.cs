using DATA.DBFactory;
using DATA.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.AccountHolder
{
    public class AccountHolderProvider
    {
        public List<AccountHolderType> GetAccountHolderType()
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                return context.AccountHolderType.ToList();
            }
        }

        public void Add(DATA.Domains.AccountHolder accountHolder)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                accountHolder.TradeMarkID = context.Trademark.FirstOrDefault().Id;
                context.AccountHolder.Add(accountHolder);
                context.SaveChanges();
            }
        }

        public List<DATA.Domains.AccountHolder> Get(int id)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var trademark = context.Trademark.Where(x => x.Id == id).FirstOrDefault();
                var accountholder = context.AccountHolder.Include("AccountHolderType").Where(x => x.TradeMarkID == trademark.Id).ToList();
                return accountholder;
                //return context.AccountHolder.Include("AccountHolderType").ToList();
            }
        }

        public void Update(DATA.Domains.AccountHolder accountHolder)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var accountholderToUpdate = context.AccountHolder.Where(x => x.Id == accountHolder.Id).FirstOrDefault();

                accountholderToUpdate.FirstName = accountHolder.FirstName;
                accountholderToUpdate.LastName = accountHolder.LastName;
                accountholderToUpdate.Contact = accountHolder.Contact;
                accountholderToUpdate.Address = accountHolder.Address;
                accountholderToUpdate.Detail = accountHolder.Detail;
                accountholderToUpdate.BankAccountNumber = accountHolder.BankAccountNumber;
                accountholderToUpdate.AccountHolderTypeID = accountHolder.AccountHolderTypeID;

                context.SaveChanges();
            }
        }

        public DATA.Domains.AccountHolder GetByID(int id)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var accountholderToGet = context.AccountHolder.Include("AccountHolderType").Where(x => x.Id ==id).FirstOrDefault();
                return accountholderToGet;
            }
        }

        public void Delete (int id)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var delete= context.AccountHolder.Where(x => x.Id == id).FirstOrDefault();
                delete.IsDeleted = true;
                context.SaveChanges();
            }

        }
        public DATA.Domains.AccountHolder GetContact(string contact)
        {
            using (BmsDbContext context= new BmsDbContext())
            {
                var getcontacts = context.AccountHolder.Where(x => x.Contact == contact).FirstOrDefault();
                return (getcontacts);
                    
            }
        }
       
    }
}
