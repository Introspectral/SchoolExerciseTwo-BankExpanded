using System.Text.Json;

namespace Uppgift_2_Bankomat_Expanded
{
    internal class Methods
    {
        public static void AccountSwitch(List<Account> accounts)
        {
            Console.Clear();
            Console.WriteLine($"-= Account overview =-\n");
            foreach (Account Item in accounts)
            {
                Console.WriteLine($"Account {Item.ID}:     {Item.Saldo}:-");
            }
            Console.WriteLine("=---------=");
            Console.WriteLine("Choose an account: ");
            Console.Write("> ");
        }
        public void Generate_account() { }

    }
}