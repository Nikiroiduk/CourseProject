using CourseProjectBL;
using CourseProjectBL.Action;
using CourseProjectBL.Enum;
using MongoDB.Driver;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CourseProjectViewConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataServices dataServices = new();

            Console.WriteLine("Enter login:");
            var login = Console.ReadLine();
            var user = dataServices.GetUserByLogin(login);
            if (user != null)
            {
                while (true)
                {
                    Console.WriteLine("Enter password:");
                    var pass = Console.ReadLine();
                    if (Security.ComparePassword(user.Password, pass))
                    {
                        Console.WriteLine("Succesfully entered!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong password.\nTry again");
                    }
                }
                Console.WriteLine($"{user.Id}: {user.Login} {user.Password}");
            }
            else
            {
                Console.WriteLine("This login doesn't exist.\nCreate new account?");
                Console.WriteLine("1. Yes\n2. No(Exit)");
                var answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.WriteLine("Enter password:");
                        var password = Console.ReadLine();
                        if (dataServices.AddNewUser(login, password))
                        {
                            Console.WriteLine("New user was succesfully added!");
                            user = dataServices.GetUserByLogin(login);
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong(");
                        }
                        break;
                    case "2":
                        Environment.Exit(0);
                        break;
                }
            }

            while (true)
            {
                Console.WriteLine("Select action");
                Console.WriteLine("1. Income\n2. Expense\n0. Exit");
                var ans = Console.ReadLine();
                switch (ans)
                {
                    case "1":
                        Console.WriteLine("Income action\n");
                        user.Actions.Add(new Expense(DateTime.UtcNow, Account.Cash, Category.Food, 150));
                        //TODO: maybe make save with INotifyPropertyChanged will be better
                        dataServices.UpdateUserData(user);
                        break;
                    case "2":
                        Console.WriteLine("Expense action\n");
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
