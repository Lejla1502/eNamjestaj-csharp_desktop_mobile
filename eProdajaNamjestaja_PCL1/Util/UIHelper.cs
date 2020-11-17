using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PCLCrypto;
using System.Threading.Tasks;

namespace eProdajaNamjestaja_PCL1.Util
{
    public class UIHelper
    {
        #region Korisnici
        public static string GenerateSalt()
        {
            byte[] arr = new byte[16];
            RNGCryptoServiceProvider cripto = new RNGCryptoServiceProvider();
            cripto.GetBytes(arr);
            return Convert.ToBase64String(arr);
        }

        public static string GenerateHash(string lozinka, string salt)
        {
            byte[] pass = Encoding.Unicode.GetBytes(lozinka);
            byte[] dodatak = Convert.FromBase64String(salt);
            byte[] forHash =new byte[pass.Length + dodatak.Length];

            System.Buffer.BlockCopy(pass, 0, forHash, 0, pass.Length);
            System.Buffer.BlockCopy(dodatak, 0, forHash, pass.Length, dodatak.Length);

            var alg = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);//.Create("SHA1");
            byte[] hashed = alg.HashData(forHash);

            return Convert.ToBase64String(hashed);
        }

#endregion

        
    }
}
