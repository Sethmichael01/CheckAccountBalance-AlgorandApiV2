using Algorand;
using Algorand.V2;
using Algorand.Client;
using Algorand.V2.Model;
using System;
using Account = Algorand.Account;
using System.Text;

namespace ConsoleApp22222
{
    class Program
    {
        static void Main(string[] args)
        {
            string ALGOD_API_ADDR = "https://testnet-algorand.api.purestake.io/ps1";
            string ALGOD_API_TOKEN = "B3SU4KcVKi94Jap2VXkK83xx38bsv95K5UZm2lab";
            // If the protocol is not specified in the address, http is added.
            //string ALGOD_API_ADDR = args[0];
            if (ALGOD_API_ADDR.IndexOf("//") == -1)
            {
                ALGOD_API_ADDR = "http://" + ALGOD_API_ADDR;
            }

            //string ALGOD_API_TOKEN = args[1];
            string SRC_ACCOUNT = "typical permit hurdle hat song detail cattle merge oxygen crowd arctic cargo smooth fly rice vacuum lounge yard frown predict west wife latin absent cup";
            string DEST_ADDR = "KV2XGKMXGYJ6PWYQA5374BYIQBL3ONRMSIARPCFCJEAMAHQEVYPB7PL3KU";
            if (!Address.IsValid(DEST_ADDR))
                Console.WriteLine("The address " + DEST_ADDR + " is not valid!");
            Account src = new Account(SRC_ACCOUNT);
            Console.WriteLine("My account address is:" + src.Address.ToString());
            if (src.ToMnemonic() != SRC_ACCOUNT)
            {
                Console.WriteLine("ToMnemonic function is wriong!");
            }

            //sign and verify bytes function test
            var bytes = Encoding.UTF8.GetBytes("examples");
            var siguture = src.SignBytes(bytes);

            Address srcAddr = new Address(src.Address.ToString());
            var verifyed = srcAddr.VerifyBytes(bytes, siguture);

            AlgodApi algodApiInstance = new AlgodApi(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            var amountBalance = algodApiInstance.AccountInformation(srcAddr.ToString());
            Console.WriteLine(amountBalance.Amount);
            

            Console.WriteLine("You have successefully arrived the end of this test, please press and key to exist.");
            Console.ReadKey();
        }
    }
}
