using System;
using System.IO;

namespace TheBank
{
    class Program
    {
        static string Conf()
        {        
            Console.WriteLine("Wciśnij dowolny klawisz aby kontynuować\n");
            return Console.ReadLine();
        }
        static void AdminAccount(BankData bankData)
        {
            bool nowAdmin = true;
            
            while (nowAdmin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Witaj w konsoli administratora.\n Wybierz jedną z opcji:\n 1: Utwórz nowe konto\n 2: Usuń istniejące konto\n 3: Zablokuj konto\n 4: Aktywuj konto\n " +
                    "5: Sprawdź ilość pieniędzy w banku\n 6: Pobierz listę zadłużonych użytkowników\n 7: Sprawdź ile pożyczek brał dany użytkownik\n 8: Wyświetl wszystkie istniejące konta\n 9: Wyjście\n");
                    int m1 = Convert.ToInt32(Console.ReadLine());


                switch (m1)
                {
                    case 1:
                        bankData.CreateAccount();
                        Conf();
                        Console.Clear();
                        break;
                    case 2:
                        bankData.DeleteAccount();
                        Conf();
                        Console.Clear();
                        break;
                    case 3:
                        bankData.DisableAccount();
                        Conf();
                        Console.Clear();
                        break;
                    case 4:
                        bankData.ActivateAccount();
                        Conf();
                        Console.Clear();
                        break;
                    case 5:
                        bankData.MoneyInBank();
                        Conf();
                        Console.Clear();
                        break;
                    case 6:
                        bankData.DebtorList();
                        Conf();
                        Console.Clear();
                        break;
                    case 7:
                        bankData.LoanList();
                        Conf();
                        Console.Clear();
                        break;
                    case 8:
                        bankData.AllUsers();
                        Conf();
                        Console.Clear();
                        break;
                    case 9:                        
                        nowAdmin = false;                        
                        Conf();
                        Console.ResetColor();
                        Console.Clear();
                        break;


                }
            }
        }

        static void UserAccount(Account account)
        {
            do
            {
                
                if (!account.Login())
                {
                    break;
                }
                if (account.isActive == false)
                {
                    Console.WriteLine("\nTwoje konto zostało zablokowane zgłoś się do administratora\n");
                    Conf();
                    break;
                }


                bool nowUser = true;
                while (nowUser)
                {
                    Console.WriteLine($"Witaj Użytkowniku {account.name} {account.surrname}\n {account}\n Wybierz co chcesz zrobić:\n 1: Wpłata pieniędzy\n 2: Wypłata pieniędzy\n" +
                    $" 3: Kredyt\n 4: Spłata Kredytu\n 5: Historia konta \n 6: Podsumowanie finansowe\n 7: Przelew\n 8: Wyjście");
                    int m2 = Convert.ToInt32(Console.ReadLine());
                    switch (m2)
                    {
                        case 1:
                            Console.WriteLine("\nWybierz kwotę którą chcesz wpłacić na konto\n");
                            double dep = Convert.ToInt32(Console.ReadLine());
                            if (dep < 0)
                            {
                                Console.WriteLine("\nNie możesz wpłacić ujemnej kwoty\n");
                                Conf();
                                Console.Clear();
                                break;                                
                            }
                            account.Deposit(dep);
                            Console.WriteLine("\nOperacja zakończona sukcesem\n");
                            Conf();
                            Console.Clear();                           
                            break;
                        case 2:
                            Console.WriteLine("\nWybierz kwotę którą chcesz wypłacić z konta\n");
                            double wit = Convert.ToInt32(Console.ReadLine());
                            if (wit < 0)
                            {
                                Console.WriteLine("\nNie możesz wpyłacić ujemnej kwoty\n");                                
                                Conf();
                                Console.Clear();
                                break;
                            }
                            if (wit > account.balance)
                            {
                                Console.WriteLine("\nNie masz tyle pieniędzy\n");
                                Conf();
                                Console.Clear();
                                break;
                            }
                            account.Withdraw(wit);
                            Console.WriteLine("\nOperacja zakończona sukcesem\n");
                            Conf();
                            Console.Clear();
                            break;
                        case 3:
                            if (account.owesBank > 0)
                            {
                                Console.WriteLine("\nNie możesz wziąć kolejnej pożyczki dopóki nie spłacisz obecnej\n");
                                Conf();
                                Console.Clear();
                                break;
                            }
                            Console.WriteLine("\nWybierz kwotę pożyczki\n");
                            double loa = Convert.ToInt32(Console.ReadLine());
                            account.Loan(loa);
                            Console.WriteLine("\nOperacja zakończona sukcesem\n");
                            Conf();
                            Console.Clear();
                            break;
                        case 4:
                            Console.WriteLine("\nWybierz kwotę którą chcesz spłacić\n");
                            double plo = Convert.ToInt32(Console.ReadLine());
                            if (plo > account.owesBank)
                            {
                                Console.WriteLine("\nNie możesz zwrócić wiecej niż pożyczyłeś\n");
                                Conf();
                                Console.Clear();
                                break;
                            }
                            account.PayLoan(plo);
                            Console.WriteLine("\nOperacja zakończona sukcesem\n");
                            Conf();
                            Console.Clear();
                            break;                                                      
                        case 5:
                            account.History();
                            Conf();
                            Console.Clear();
                            break;
                        case 6:
                            account.CashInCashOut();
                            Conf();
                            Console.Clear();
                            break;
                        case 7:
                            account.MoneyTransfer();
                            Conf();
                            Console.Clear();
                            break;
                        case 8:
                            nowUser = false;
                            Conf();
                            Console.Clear();
                            break;
                    }
                } break;
            }
            while (true);


        }
        static void Main(string[] args)
        {
            

            BankData bankData = new BankData();

            do
            {
                Console.WriteLine("\nWitaj w Saigon Banku #1 na Kajmanach \n Wybierz opcję: \n 1: Logowanie administratora\n 2: Logowanie użytkownika\n 3: Wyjście\n");
                int m1 = Convert.ToInt32(Console.ReadLine());
                if (m1 == 1)
                {
                    Console.Clear();
                    AdminAccount(bankData);
                    
                }
                else if (m1 == 2)
                {

                    Console.WriteLine("\nPodaj numer ACID\n");
                    int m3 = Convert.ToInt32(Console.ReadLine());

                    foreach (Account account in bankData.accounts)
                    {                       
                        if (account.AccId == m3)
                        {
                            Console.Clear();
                            UserAccount(account);
                            
                        }
                        else if (m3 < 1000 || m3 > 9999) Console.WriteLine("\nPodałeś złą wartość (Numery ACID składają się z 4 cyfr)\n");
                    }
                }
                else if (m1 == 3)
                {
                    break;
                }
            } while (true);
            


        }
    }
}
