using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ApiAutenticationDotNet8
{
    public class SHA512
    {
        public static string Criptografar(string value)
        {
            UnicodeEncoding ue = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = ue.GetBytes(value);

            SHA512Managed hashString = new SHA512Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
                hex += String.Format("{0:x2}");

            return hex;    

        }
    }
}