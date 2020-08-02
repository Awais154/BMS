using DATA.DBFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA.Domains;


namespace Provider.User
{
   public class UserProvider
    {
        public DATA.Domains.User Authenticate(string emailAddress,string password)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var getEmail = context.User.Where(x => x.Email == emailAddress && x.Password==password).FirstOrDefault();
                return getEmail;
            }
        }
        public DATA.Domains.User GetEmail(string email)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var getEmail = context.User.Where(x => x.Email == email).FirstOrDefault();
                return(getEmail);
            }
        }



        public List<DATA.Domains.User> GetUser(int id)
        {
            using (BmsDbContext context = new BmsDbContext())
            {
                var trademarkuser = context.Trademark.Where(x => x.Id == id).FirstOrDefault();
                var user = context.User.Where(y => y.Id == trademarkuser.Id).ToList();
                return user;
                //return context.User.ToList();
            }
        }

        public DATA.Domains.User GetById(int id)
        {
            using(BmsDbContext context = new BmsDbContext())
            {
                var user = context.User.Where(x => x.Id == id).FirstOrDefault();
                return user;
            }
        }

        public void update(DATA.Domains.User user)
        {
            using(BmsDbContext context= new BmsDbContext())
            {
                var usertouptade = context.User.Where(x => x.Id == user.Id).FirstOrDefault();
                usertouptade.Password = user.Password;
                context.SaveChanges();
            }
        }
        #region Wajhat
        //public DATA.Domains.User GetUser(int id= 1)
        //{
        //    using (BmsDbContext context = new BmsDbContext())
        //    {
        //        var user = context.User.Where(x => x.Id ==id).FirstOrDefault();
        //        return user;
        //    }

        //}

        //public DATA.Domains.User UpdateUser(DATA.Domains.User user)
        //{
        //    using(BmsDbContext context = new BmsDbContext())
        //    {
        //        var updated= context.User.Where(x=>x.Id == user.Id).FirstOrDefault();
        //        updated.Password = user.Password;
        //        updated.CreatedOn = DateTime.Now;
        //        context.SaveChanges();

        //        return updated;
        //    }
        //}
        #endregion
    }
}
