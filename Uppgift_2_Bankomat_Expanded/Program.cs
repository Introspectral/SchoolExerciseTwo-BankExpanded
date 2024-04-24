using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.Json;
using System.Net;


namespace Uppgift_2_Bankomat_Expanded
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Account> accounts;
            try
            {
                string read_file = System.IO.File.ReadAllText("save_accounts.json");
                accounts=JsonSerializer.Deserialize<List<Account>>(read_file) ?? new List<Account>();
            }
            catch
            {
                Account account_1 = new Account(1, 1000, "1234");
                Account account_2 = new Account(2, 300, "4235");
                Account account_3 = new Account(3, 0, "7443");
                Account account_4 = new Account(4, 0, "7244");
                Account account_5 = new Account(5, 0, "7457");
                Account account_6 = new Account(6, 0, "6973");
                Account account_7 = new Account(7, 0, "1258");
                Account account_8 = new Account(8, 0, "4527");
                Account account_9 = new Account(9, 0, "1634");
                Account account_10 = new Account(10, 750, "1375");

                accounts = new List<Account>();
                accounts.Add(account_1);
                accounts.Add(account_2);
                accounts.Add(account_3);
                accounts.Add(account_4);
                accounts.Add(account_5);
                accounts.Add(account_6);
                accounts.Add(account_7);
                accounts.Add(account_8);
                accounts.Add(account_9);
                accounts.Add(account_10);
            }

            int total_saldo = 0;

            string[] menu = { "1: Deposit", "2: Withdraw", "3: List accounts", "4: Quit" };


            do
            {
                Console.Clear();
                Console.WriteLine("Gringotts Wizarding Bank");
                Console.WriteLine("=---------=");

                for (int i = 0; i < menu.Length; i++)
                {
                    Console.WriteLine(menu[i]);
                }
                Console.Write("\n" + "> ");

                string menu_selection = Console.ReadLine();

                try
                {
                    switch (menu_selection)
                    {
                        case "1":// Deposit

                            Methods.AccountSwitch(accounts);
                            string dep_acc = Console.ReadLine();

                            foreach (Account account in accounts)
                            {
                                if (account.ID == int.Parse(dep_acc))
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Current Balance on Account {account.ID}    \n{account.Saldo}:-");
                                    Console.WriteLine("=---------=");
                                    Console.WriteLine($"Deposit ammount:");
                                    Console.Write("> ");
                                    string dep_amt = Console.ReadLine();
                                    account.Deposit(int.Parse(dep_amt));
                                    Console.Clear();
                                    Console.WriteLine($"You deposited: \n{dep_amt}:-\n=---------=" +
                                            $"\nCurrent Balance on Account {account.ID}    \n{account.Saldo}:-");
                                    Console.ReadLine();
                                }
                            }

                            break;

                        case "2":// Withdraw


                            Methods.AccountSwitch(accounts);
                            string wit_acc = Console.ReadLine();

                            foreach (Account account in accounts)
                            {
                                if (account.ID == int.Parse(wit_acc))
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Current Balance on Account {account.ID}    \n{account.Saldo}:-");
                                    Console.WriteLine("=---------=");
                                    Console.WriteLine($"withdrew ammount:");
                                    Console.Write("> ");
                                    string wit_amt = Console.ReadLine();
                                    if (int.Parse(wit_amt) <= account.Saldo)
                                    {
                                        account.Withdraw(int.Parse(wit_amt));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du försöker ta ut mer än du har");
                                        Console.ReadLine();
                                        break;
                                    }
                                    Console.Clear();
                                    Console.WriteLine($"You withdrew: \n{wit_amt}:-\n=---------=" +
                                            $"\nCurrent Balance on Account {account.ID}    \n{account.Saldo}:-");
                                    Console.ReadLine();
                                    break;
                                }

                            }

                            break;

                        case "3": // List Accounts
                            Console.Clear();
                            Console.WriteLine($"-= Account overview =-\n");
                            total_saldo = 0;
                            foreach (Account item in accounts)
                            {
                                Console.WriteLine($"Account {item.ID}:     {item.Saldo}:-");
                                total_saldo += item.Saldo;
                            }
                            Console.WriteLine($"=---------=\nTotal balance:   {total_saldo}:-");
                            Console.ReadLine();
                            break;

                        case "4": // Exit

                            string save_account = JsonSerializer.Serialize(accounts);
                            System.IO.File.WriteAllText("save_accounts.json", save_account);
                            Console.Clear();
                            Console.WriteLine("Quit");
                            return;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Du har angivit ett alternativ som inte finns");
                    Console.ReadLine();
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Du har inte angivit något alternativ");
                    Console.ReadLine();
                }

            } while (true);
        }

    }
}
