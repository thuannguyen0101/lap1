using System;
using System.Text;
using lap1.entity;
using lap1.model;
using lap1.service;

namespace lap1.controller
{
    public class UserController
    {
        public void CreateUser()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            User user = new User();
            Console.WriteLine("Please enter info user\n");
            Console.WriteLine("--------------------------\n");
            Console.WriteLine("please enter First name:");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("please enter Last name:");
            user.LastName = Console.ReadLine();
            Console.WriteLine("please enter Email:");
            user.Email = Console.ReadLine();
            Console.WriteLine("please enter Password:");
            string password = Console.ReadLine();
            Console.WriteLine("please enter Phone:");
            user.Phone = Console.ReadLine();
            Console.WriteLine("please enter Address:");
            user.Address = Console.ReadLine();
            UserService userService = new UserService();
            userService.CreateUser(user , password);
        }

        public User Login()
        {
            UserService userService = new UserService();
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            UserModel userModel = new UserModel();
            Console.WriteLine("please enter email:");
            string email = Console.ReadLine();
            Console.WriteLine("please enter password:");
            string password = Console.ReadLine();
            User _user = userService.Login(email,password);
            return _user;
        }
    }
}