using System;
using System.Collections.Generic;
using System.Text;
using lap1.entity;
using lap1.model;
using lap1.service;


namespace lap1.controller
{
    public class AccountController
    {
        public User Recharge(User user)
        {
            AccountService accountService = new AccountService();
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("Please enter the amount to deposit");
            double money = double.Parse(Console.ReadLine());
            User _user = accountService.Recharge(user , money);
            return _user;
        }
        public User Withdrawal(User user)
        {
            AccountService accountService = new AccountService();
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("Please enter the amount to withdraw");
            double money = double.Parse(Console.ReadLine());
            User _user =  accountService.Withdrawal(user, money);
            return _user;
        }
        public User Transfers(User user)
        {
            AccountService accountService = new AccountService();
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("Please enter the account to transfers");
            string receiver = Console.ReadLine();
            Console.WriteLine("Please enter the amount to transfers");
            double money = double.Parse(Console.ReadLine());
            User _user = accountService.Transfers(user, money, receiver);
            return _user;
        }
        public void TransactionHistory(User user)
        {
            TransactionModel tranModel = new TransactionModel();
            string cardNumber = user.CardNumber;
            List<Transaction> list = tranModel.TransactionHistory(cardNumber);

            Console.WriteLine("Transaction type \t\t Status \t\t\t Create At \t\t\t\t Description");
            foreach (Transaction transaction in list)
            {
                string a = null;
                if (transaction.Status == 1)
                {
                    a = "success";
                }
                else
                {
                    a = "cancel";
                }

                Console.WriteLine(
                    $" {transaction.Type}\t\t\t{a}  \t\t\t{transaction.CreatedAt}\t\t{transaction.Message}");
            }
        }
        
    }
}