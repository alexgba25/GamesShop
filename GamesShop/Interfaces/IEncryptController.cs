using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesShop.Interfaces
{
    public interface IEncryptController
    {
        string Encrypt(string plainText);
        string Decrypt(string encryptedText);
    }
}