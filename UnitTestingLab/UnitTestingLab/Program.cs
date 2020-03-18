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

                Console.WriteLine("");
                Console.WriteLine($"Thank you for playing {userName}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"You have invalid choice {e.Message}");
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
                if (userChoice > 4)
                {
                    Console.WriteLine($"Please enter within the choice {name}");
                    return false;
                }
                else if (userChoice == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Your Balance is {defaultMoney}");
                }
                else if (userChoice == 2)
                {
                    //WithdrawCash(name);
                }
                else if (userChoice == 3)
                {
                    //DepositCash(name);
                }
                else if (userChoice == 4)
                {
                    return true;
                }

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

        }
    }
}
