using System;
using System.Collections.Generic;
using System.Text;

namespace TheBank
{
    class Account
    {
        BankData bankData;
        public double inoutplus;
        public double inoutminus;
        public bool isActive;
        public double balance;
        public string name;
        public string surrname;
        public string password;
        public int AccId;
        public double owesBank;   
        public double moneyInBank;
        public double moneyLoaned;
        public List<string> accountHistory;
        public int LoanNumber;
        
        public Account(string name, string surrname, string password, int AccId, BankData bankData)
        {
            this.AccId = AccId;
            this.bankData = bankData;
            isActive = true;           
            owesBank = 0;
            LoanNumber = 0;
            inoutplus = 0;
            inoutminus = 0;           
            accountHistory = new List<string>();
            this.name = name;
            this.surrname = surrname;
            balance = 0;
            this.password = password;           
        }

        public void Deposit(double cash)
        {           
            moneyInBank += cash;
            balance += cash;

            accountHistory.Add("Użytkownik wpłacił " + cash);
            inoutplus += cash;
        }
        public void Withdraw(double cash)
        {          
            moneyInBank -= cash;
            balance -= cash;

            accountHistory.Add("Użytkownik wypłacił " + cash);
            inoutminus += cash;
        }
        public void Loan(double cashLoan)
        {
            balance += cashLoan;
            owesBank += cashLoan;
            LoanNumber++;

            accountHistory.Add("Użytkownik pożyczył " + cashLoan);
            moneyLoaned += cashLoan;

        }
        public void PayLoan(double cashLoan)
        {           
            balance -= cashLoan;
            owesBank -= cashLoan;

            accountHistory.Add("Użytkownik oddał " + cashLoan);
            moneyLoaned -= cashLoan;
        }
        public void History()
        {
            foreach (string s in accountHistory)
            {
                Console.WriteLine(s);
            }
        }
        public void CashInCashOut()
        {
            Console.WriteLine($"\nOd początku istnienia tego konta użytkownik wpłacił {inoutplus} i wypłacił {inoutminus}\n");
        }
        public bool Login()
        {

            if (isActive == true)
            {
                Console.WriteLine($"Użytkownik {name} {surrname}\n Podaj Hasło\n");
                if (password == Console.ReadLine())
                {
                    Console.WriteLine("\nLogowanie udane\n");
                    return true;
                }
                else
                {
                    Console.WriteLine("\nNieprawidłowe hasło\n");
                    return false;
                }
            }
            else if (isActive == false) 
            {
                Console.WriteLine("\nTwoje konto zostało zablokowane przez administratora\n");
                return false; 
            }
            return false;
        }
        public void MoneyTransfer()
        {
            Console.WriteLine("\nPodaj ACID konta na które chciałbyś zrobić przelew\n");
            int b1 = Convert.ToInt32(Console.ReadLine());

            foreach (Account account in bankData.accounts)
            {
                if(account.AccId == b1)
                {
                    Console.WriteLine($"\nJaką kwotę chciałbyś przesłać na konto o numerze ACID {b1}?\n");
                    int sum = Convert.ToInt32(Console.ReadLine());

                    if (sum > 0 & balance > sum)
                    {
                        balance -= sum;
                        account.balance += sum;
                        Console.WriteLine($"Przelew kwoty {sum} na konto {account.AccId} zakończony pomyślnie\n");
                        accountHistory.Add($"Przelew - {sum}");                      
                    }
                    else Console.WriteLine("\nPodana kwota jest błędna\n");
                }
            }
        }

        public override string ToString()
        {
            return $"\nUżytkownik {name} {surrname} posiada {balance}zł Unikatowy numer ACID to {AccId}\n";
        }
    }
}
