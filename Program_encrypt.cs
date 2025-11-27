using System;
using AspNetCore.LegacyAuthCookieCompat;

class Program
{
    static void Main(string[] args)
    {
        string validationKey = "EBF9076B4E3026BE6E3AD58FB72FF9FAD5F7134B42AC73822C5F3EE159F20214B73A80016F9DDB56BD194C268870845F7A60B39DEF96B553A022F1BA56A18B80";
        string decryptionKey = "B26C371EA0A71FA5C3C9AB53A343E9B962CD947CD3EB5861EDAE4CCC6B019581";

        // Convert keys
        byte[] decryptionKeyBytes = HexUtils.HexToBinary(decryptionKey);
        byte[] validationKeyBytes = HexUtils.HexToBinary(validationKey);

        var encrypter = new LegacyFormsAuthenticationTicketEncryptor(
            decryptionKeyBytes,
            validationKeyBytes,
            ShaVersion.Sha256
        );

        // Create a new ticket
        var ticket = new FormsAuthenticationTicket(
            version: 1,
            name: "ken.w",
            issueDate: DateTime.Now,
            expiration: DateTime.Now.AddMinutes(10),
            isPersistent: true,
            userData: "Web Users",
            cookiePath: "/"
        );

        // Encrypt it
        string encryptedCookie = encrypter.EncryptCookie(ticket);

        Console.WriteLine("Encrypted Cookie:");
        Console.WriteLine(encryptedCookie);
        Console.ReadLine();
    }
}
