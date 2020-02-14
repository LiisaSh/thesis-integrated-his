using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHIS.Models.IdentityModels
{
    public class EncryptionModel
    {
        IDataProtector _iPro;

        // the 'provider' parameter is provided by DI
        public EncryptionModel(IDataProtectionProvider provider)
        {
            _iPro = provider.CreateProtector("EncryptionModel");
        }

        public string getProtectedUsername(string username)
        {

            // protect string
            string protectedusername = _iPro.Protect(username);

            // protect string
            return protectedusername;

            //string unProtectedString = _iPro.Unprotect(protectedString);
        }

        public string getProtectedPassword(string password)
        {

            // protect string
            string protectedpassword = _iPro.Protect(password);

            // protect string
            return protectedpassword;

            //string unProtectedString = _iPro.Unprotect(protectedString);
        }
        public string getUnProtectedUsername(string username)
        {

            string unprotectedusername = _iPro.Unprotect(username);
            return unprotectedusername;

        }

        public string getUnProtectedPassword(string password)
        {


            string protectedString = _iPro.Unprotect(password);
            return protectedString;


        }
    }
}

