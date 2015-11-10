using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoneWolf.Common;
using LoneWolf.Common.Encryption.Helpers;
using System.Windows.Forms;


namespace LoneWolf.IDEncryption
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Write("Do you wish to encrypt(Type 'e') or decrypt(Type 'd')?");
            var process = Console.ReadLine();
            try
            {
                if (process.Trim().ToLower() == "e")
                    DoEncryption();
                else if (process.Trim().ToLower() == "d")
                    DoDecryption();
                else
                {
                    Console.WriteLine("That is not a valid selection. Please restart and try again.");
                    Console.Read();
                }
                Console.WriteLine("Please any key to exit.");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("An error occurred attempting to process your input. Please verify that you have entered the correct input and try again.");
                Console.Read();
            }
            
        }

        [STAThread]
        static void DoEncryption()
        {
            Console.Write("Please enter the ID you wish to encrypt:   ");
            var id = Console.Read();

            var encryptedID = EncryptionHelper.Encrypt(id);
            Console.WriteLine("Encrypted ID: " + encryptedID);
            Clipboard.SetText(encryptedID);
            Console.WriteLine("Encrypted ID has been added to your clipboard.");
            Console.ReadLine();

        }

        [STAThread]
        static void DoDecryption()
        {
            Console.Write("Please enter the ID you wish to decrypt:   ");
            var id = Console.ReadLine();

            var decryptedID = EncryptionHelper.Decrypt(id);
            Console.WriteLine("Decrypted ID: " + decryptedID);
            Clipboard.SetText(decryptedID);
            Console.WriteLine("Decrypted ID has been added to your clipboard.");
            Console.ReadLine();

        }
    }
}
