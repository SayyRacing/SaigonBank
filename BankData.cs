using System;
using System.Collections.Generic;
using System.Text;

namespace TheBank
{
    class BankData
    {
        public List<Account> accounts;
        double cash;
        double loanedCash;
        int acid = 1000;
        public BankData()
        {
            accounts = new List<Account>();
        }

        public void CreateAccount()
        {
            Console.WriteLine("\nPodaj Imię\n");
            string name = Console.ReadLine();
            Console.WriteLine("\nPodaj Nazwisko\n");
            string surrname = Console.ReadLine();
            Console.WriteLine("\nPodaj Hasło\n");
            string password = Convert.ToString(Console.ReadLine());            
                
            Account account = new Account(name, surrname, password, acid, this);
            acid++;
            account.isActive = true;          
            Console.WriteLine($"Utworzono konto {account}\n");
            accounts.Add(account);
        }
        public void DisableAccount()
        {
            Console.WriteLine("\nPodaj ACID konta które chcesz zablokować\n");
            int b1 = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccId == b1)
                {

                    accounts[i].isActive = false;
                    if (accounts[i].isActive == false)
                    {
                        Console.WriteLine($"\nZablokowano konto {accounts[i].name} {accounts[i].surrname}\n");
                    }
                    break;
                }

            }
        }
        public void ActivateAccount()
        {
            Console.WriteLine("\nPodaj ACID konta które chcesz aktywować\n");
            int b1 = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccId == b1)
                {

                    accounts[i].isActive = true;
                    Console.WriteLine($"\nOdblokowano konto {accounts[i].name} {accounts[i].surrname}\n");
                    break;
                }
                
            }
        }
        public void DeleteAccount()
        {
            Console.WriteLine("\nPodaj ACID konta które chcesz usunąć\n");
            int b1 = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccId == b1)
                {
                    Console.WriteLine($"\nUsunięto konto {accounts[i].name} {accounts[i].surrname}\n");
                    accounts.Remove(accounts[i]);                   
                    break;
                }
                
            }
        }
        public void MoneyInBank()
        {
            cash = 0;
            loanedCash = 0;

            foreach (Account account in accounts)
            {
                cash += account.balance;
            }
            foreach (Account account in accounts)
            {
                loanedCash += account.owesBank;
            }
            Console.WriteLine($"\nObecnie w banku znajduje się {cash}\n Obecnie w wyniku pożyczek z banku pożyczono {loanedCash}\n");
        }
        public void DebtorList()
        {
            Console.WriteLine("\nOto obecnie zadłużeni klięci:\n");
            foreach (Account account in accounts)
            {               
                if (account.owesBank > 0)
                {
                    Console.WriteLine(account);
                }
            }
        }
        public void LoanList()
        {
            Console.WriteLine("\nPodaj ACID konta którego hisorię pożyczek chcesz sprawdzić\n");
            int b1 = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccId == b1)
                {
                    Console.WriteLine($"\nOto liczba pożyczek zaciągniętych przez użytkownika {accounts[i].LoanNumber}\n");
                    break;
                }
            }
        }
        public void AllUsers()
        {
            Console.WriteLine("\nOto wszystkie konta w banku\n");
            foreach (Account account in accounts)
            {
                Console.WriteLine(account);
            }
        }
    }
}
