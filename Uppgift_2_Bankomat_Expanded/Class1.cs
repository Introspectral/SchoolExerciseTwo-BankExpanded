using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_2_Bankomat_Expanded
{
    public class Account
    {
        public int ID { get; set; }
        private int saldo;
        public int Saldo { get { return saldo; } }
        public string? Account_number { get; set; }
        public Account(int id, int saldo, string account_number)
        {
            ID = id;
            this.saldo = saldo;
        }
        public void Deposit(int ammount)
        {
            if (ammount > 0)
            {
                saldo += ammount;
                Console.WriteLine($"{ammount} has been deposited to the account");
            }
        }
        public void Withdraw(int ammount)
        {
            if (ammount <= saldo)
            {
                saldo -= ammount;
                Console.WriteLine($"{ammount} has been withdrawn from the account");
            }
        }
    }

}
