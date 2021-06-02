using System;
using lap1.entity;
using lap1.model;


namespace lap1.service
{
    public class AccountService
    {
        
        
        public User Recharge(User user , double money)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[6];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            
            if (money > 0)
            {
                TransactionModel transactionModel = new TransactionModel();
                string account = user.Email;
                Transaction transaction = new Transaction();
                AccountModel accountModel = new AccountModel();
                User _user =  accountModel.Recharge(account, money);
                if (_user != null)
                {
                    transaction.Code = finalString;
                    transaction.SenderAccountNumber = account;
                    transaction.ReceiverAccountNumber = account;
                    transaction.Money = money;
                    transaction.Type = "Recharge";
                    transaction.Status = 1;
                    transaction.Message =   $"You have successfully added to your account {_user.CardNumber} the amount is {money}$ balance {_user.Balance}";
                    transaction.CreatedAt = DateTime.Now;
                    transaction.UpdatedAt = DateTime.Now;
                    transactionModel.Store(transaction);
                }
                return _user;
            }
            else
            {
                Console.WriteLine("Amount cannot be a negative number");
                return user;
            }
        }
        public User Withdrawal(User user , double money)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[6];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            AccountModel accountModel = new AccountModel();
            string receiver = user.Email;
            string account = user.Email;
            string type = "Withdrawal";
            if (money > 0)
            {
                if (money < user.Balance )
                {
                    TransactionModel transactionModel = new TransactionModel();
                    Transaction transaction = new Transaction();
                    User _user = accountModel.Withdrawal(account, money);
                    if (_user != null)
                    {
                        transaction.Code = finalString;
                        transaction.SenderAccountNumber = account;
                        transaction.ReceiverAccountNumber = account;
                        transaction.Money = money;
                        transaction.Type = "Recharge";
                        transaction.Status = 1;
                        transaction.Message =    $"You have successfully withdrawal to your account {_user.CardNumber} the amount is {money}$ balance {_user.Balance}";
                        transaction.CreatedAt = DateTime.Now;
                        transaction.UpdatedAt = DateTime.Now;
                        transactionModel.Store(transaction);
                    }
                    return _user;
                }
                else
                {
                    Console.WriteLine("\tInsufficient balance in the account !");
                    return user;
                }
            }
            else
            {
                Console.WriteLine("Amount cannot be a negative number");
                return user;
            }
        }

        public User Transfers(User user, double money, string receiver)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[6];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            TransactionModel transactionModel = new TransactionModel();
            var finalString = new String(stringChars);
            Transaction transactionReceiver = new Transaction();
            Transaction transactionRemitters = new Transaction();
            string remitters = user.Email;
            double sun = user.Balance - money;
            AccountModel accountModel = new AccountModel();
            if (money < user.Balance && money > 0)
            {
                User _user = accountModel.Transfers(remitters, money, receiver, sun);
                if (_user != null)
                {
                    // thong bao nguoi nhan
                    transactionReceiver.Code = finalString;
                    transactionReceiver.SenderAccountNumber = remitters;
                    transactionReceiver.ReceiverAccountNumber = receiver;
                    transactionReceiver.Money = money;
                    transactionReceiver.Type = "Recharge";
                    transactionReceiver.Status = 1;
                    transactionReceiver.Message =  $"You get amount {money}$ from account number {user.CardNumber}";
                    transactionReceiver.CreatedAt = DateTime.Now;
                    transactionReceiver.UpdatedAt = DateTime.Now;
                    transactionModel.Store(transactionReceiver);
                    // thong bao nguoi gui
                    transactionRemitters.Code = finalString;
                    transactionRemitters.SenderAccountNumber = remitters;
                    transactionRemitters.ReceiverAccountNumber = receiver;
                    transactionRemitters.Money = money;
                    transactionRemitters.Type = "Transfers";
                    transactionRemitters.Status = 1;
                    transactionRemitters.Message =   $"You have successfully transfer the amount {money}$ to account {receiver} your balance is {_user.Balance}$";
                    transactionRemitters.CreatedAt = DateTime.Now;
                    transactionRemitters.UpdatedAt = DateTime.Now;
                    transactionModel.Store(transactionRemitters);
                }
                return _user;
            }
            else if (money < 0)
            {
                Console.WriteLine("Amount cannot be a negative number");
                return user;
            }
            else
            {
                Console.WriteLine("\tInsufficient balance in the account !");
                return user;
            }
        }
    }
}