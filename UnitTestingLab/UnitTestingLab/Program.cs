using System;
using System.ComponentModel.Design;
using System.Text;

namespace UnitTestingLab
{
    public class Program
    {
        // This is default money for user
        public static decimal defaultMoney = 5000.00m;
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(@"
                                #================#
                                # G-Unit Testing #
                                # created by Jin #
                                #================#");
                Console.WriteLine("What is your name");
                string userName = Console.ReadLine();
                bool menuBool = false;
                while (!menuBool)
                {
                    menuBool = Interface(userName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"You have invalid choice {e.Message}");
            }
            finally
            {
                Console.WriteLine("");
                Console.WriteLine("Thank you!");
                Environment.Exit(0);
            }
        }

        public static bool Interface(string name)
        {
            try
            {
                // This is interface for user to choose amongst given menu
                Console.WriteLine("");
                Console.WriteLine($"Hi {name}, welcome to the CodeFellowATM");
                Console.WriteLine($"Please choose from the option following");
                Console.WriteLine($"1. View Balance");
                Console.WriteLine($"2. Withdraw Money");
                Console.WriteLine($"3. Deposit Money");
                Console.WriteLine($"4. Exit");

                // Choice will be saved in the 
                int userChoice = Convert.ToInt32(Console.ReadLine());

                // This is to disallow user to put choice that is not within the option
                if (userChoice > 4)
                {
                    Console.WriteLine($"Please enter within the choice {name}");
                    return false;
                }
                // To Check the balance
                else if (userChoice == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Your Balance is {defaultMoney}");
                    Console.ResetColor();
                }
                // To Withdraw the money
                else if (userChoice == 2)
                {
                    // Asking user how much they want to withdraw
                    Console.WriteLine("How much do you want to withdraw?");
                    decimal withdrawMoney = Convert.ToDecimal(Console.ReadLine());

                    // If user is withdrawing more than they have console return this statement
                    if (withdrawMoney > defaultMoney)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{name}, you took out more than current balance, you will only receive {defaultMoney-1}");
                        Console.ResetColor();
                        WithdrawCash(withdrawMoney);
                    }
                    // If user has enough money this will invoke 
                    else
                    {
                        decimal resultMoney = WithdrawCash(withdrawMoney);
                        Console.Clear();
                        Console.WriteLine($"{name}, you took out {withdrawMoney}");
                    }
                }
                // To deposit money
                else if (userChoice == 3)
                {
                    // Asking how much user wants to deposit
                    Console.WriteLine("How much do you want to deposit?");
                    decimal despositMoney = Convert.ToDecimal(Console.ReadLine());
                    DepositCash(despositMoney);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You deposit {despositMoney}");
                    Console.ResetColor();
                }
                // Exit mode
                else if (userChoice == 4)
                {
                    return true;
                }

                // Checking with user if they continue again
                Console.WriteLine($"{name}, would you like to continue? (y/n)");
                string lastChoice = Console.ReadLine().ToLower();
                if (lastChoice == "y")
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("You have enter wrong format, please try correct input");
                return false;
            }
            catch (OverflowException)
            {
                Console.WriteLine("You have entered incorrect data type input, please try again");
                return false;
            }
            // message from that it is invalid 
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            // method to withdraw cash
            static decimal WithdrawCash(decimal money)
            {
                defaultMoney -= money;
                if (defaultMoney < 0)
                    defaultMoney = 1;
                return defaultMoney;
            }

            // method to deposit cash
            static decimal DepositCash(decimal money)
            {
                // if the user put negative vaue it will throw exception that will be caught in catch prior stack catch block
                if (money < 0)
                    throw new ArgumentException("Please use withdraw option to get negative money");
                defaultMoney += money;
                return defaultMoney;
            }
        }
    }
}
