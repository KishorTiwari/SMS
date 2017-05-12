using SMS.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Data.DAL;
using SMS.Data.ViewModels;
using SMS.Data.Validations;
using System.Web.Security;

namespace SMS.Data.ServicesImplimentation
{
    public class FormAuthProvider : IAuthProvider
    {
        public bool Authenticate(string email, string password)
        {
            using(var db = new SMSContext())
            {

                var user = db.Trader.Single(t => t.Email == email);
                if(user != null)
                {
                    var salt = user.Salt;
                    if(password == Encryption.SHA1(password + salt))
                    {
                        FormsAuthentication.SetAuthCookie(email, false);
                        return true;
                    }                   
                }
                return false;
            }
        }
    }
}
