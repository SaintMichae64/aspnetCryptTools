sudo bash -c 'cat > Program.cs << "EOF"
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

      byte[] decryptionKeyBytes = HexUtils.HexToBinary(decryptionKey);
      byte[] validationKeyBytes = HexUtils.HexToBinary(validationKey);

      var legacyFormsAuthenticationTicketEncryptor = new LegacyFormsAuthenticationTicketEncryptor(decryptionKeyBytes, validationKeyBytes, ShaVersion.Sha256);

      FormsAuthenticationTicket decryptedTicket = legacyFormsAuthenticationTicketEncryptor.DecryptCookie("EC7AB1F8A144196931E787D7E339D308A420BC8C7777717B588C8C5D0881F8657667F236BBDEAC0F54237B4D04FFCD749336656EE65B6346CCA87801C530CADB67D5EF30534A0A5BE42A593D130E6575F0B8C448F66C9CAED9FBEBC2EF62C89883809A45DEAC3C68BBC44C64A6A7A0E3B3EF83A29D4B59F188BCACF4E53DE0EE2260535C4A91D3BB52EBDDBF2FE3A0D196882B8FFB5465B4D98197DFE1B5C7B3");
      Console.WriteLine(decryptedTicket.Version);
      Console.WriteLine(decryptedTicket.Name);
      Console.WriteLine(decryptedTicket.IssueDate);
      Console.WriteLine(decryptedTicket.Expiration);
      Console.WriteLine(decryptedTicket.IsPersistent);
      Console.WriteLine(decryptedTicket.UserData);
      Console.WriteLine(decryptedTicket.CookiePath);
      Console.ReadLine();
    }
}
EOF'
