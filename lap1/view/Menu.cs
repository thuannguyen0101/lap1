using System;
using System.Text;
using lap1.controller;
using lap1.entity;

namespace lap1.view
{
    public class Menu
    {
        public void GetMenu()
        {
            User user = null;
            AccountController accountController = new AccountController();
            UserController userController = new UserController();
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("\t---Welcome to spring-hero-bank by Thuận Nguyễn---\n");
            Boolean LoggedInAccount = false;
            while (true)
            {
                if (LoggedInAccount == false)
                {
                    Console.WriteLine("please enter choice (1-3)\n");
                    Console.WriteLine("-1: Create new account");
                    Console.WriteLine("-2: Login account");
                    Console.WriteLine("-3: Contact Us");
                    Console.WriteLine("-4: Exit");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1 || choice == 2 || choice == 3|| choice == 4 )
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Create new account\n");
                                userController.CreateUser();
                                break;
                            case 2:
                                Console.WriteLine("Login account\n");
                                user = userController.Login();
                                LoggedInAccount = true;
                                break;
                            case 3:
                                Console.WriteLine("Chúng tôi là tâp đoàn đa quốc gia " +
                                                  "Với 1.000.000 năm kinh nghiệm trong lĩnh vực ngân hàng" +
                                                  "Rất vui khi đc bạn lưa chọn và tin tưởng");
                                break;
                        }

                        if (choice == 4)
                        {
                            Console.WriteLine("");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter options(1-3)");
                    }
                }
                else
                {
                    
                    Console.WriteLine($"\tWelcome:     {user.FirstName} {user.LastName}");
                    Console.WriteLine($"\tBalance:     {user.Balance}$");
                    Console.WriteLine($"\tCard number: {user.CardNumber}");
                    Console.WriteLine("-1: Transfers");
                    Console.WriteLine("-2: Recharge");
                    Console.WriteLine("-3: Withdrawal");
                    Console.WriteLine("-4: Transaction history");
                    Console.WriteLine("-5: Logout");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice != null)
                    {
                        switch (choice)
                        {
                            case 1:
                                user = accountController.Transfers(user);
                                break;
                            case 2:
                                user = accountController.Recharge(user);
                                break;
                            case 3:
                                user = accountController.Withdrawal(user);
                                break;
                            case 4:
                                accountController.TransactionHistory(user);
                                break;
                            case 5:
                                Console.WriteLine("It's a pleasure to serve you");
                                user = null;
                                break;
                        }
                    }
                }
            }
        }
    }
}