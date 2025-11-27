using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCore.LegacyAuthCookieCompat;

class Program
{
    static void Main(string[] args)
    {
      string validationKey = "EBF9076B4E3026BE6E3AD58FB72FF9FAD5F7134B42AC73822C5F3EE159F20214B73A80016F9DDB56BD194C268870845F7A60B39DEF96B553A022F1BA56A18B80";
      string decryptionKey = "B26C371EA0A71FA5C3C9AB53A343E9B962CD947CD3EB5861EDAE4CCC6B019581";

      var issueDate = DateTime.Now;
      var expiryDate = issueDate.AddHours(1);
      var formsAuthenticationTicket = new FormsAuthenticationTicket(1, "web_admin", issueDate, expiryDate, false, "Web Administrators", "/");


      byte[] decryptionKeyBytes = HexUtils.HexToBinary(decryptionKey);
      byte[] validationKeyBytes = HexUtils.HexToBinary(validationKey);

      var legacyFormsAuthenticationTicketEncryptor = new LegacyFormsAuthenticationTicketEncryptor(decryptionKeyBytes, validationKeyBytes, ShaVersion.Sha256);

      var encryptedText = legacyFormsAuthenticationTicketEncryptor.Encrypt(formsAuthenticationTicket);

      Console.WriteLine(encryptedText);
    }
}
