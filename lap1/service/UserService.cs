using System;
using System.Dynamic;
using lap1.entity;
using lap1.helper;
using lap1.model;

namespace lap1.service
{
    public class UserService
    {
        public void CreateUser(User user,string password)
        {
            UserModel userModel = new UserModel();
            DateTime thisDay = DateTime.Now;
            Md5 md5 = new Md5();
            Random rnd = new Random();
            double one = rnd.Next(0000, 9999);
            double two = rnd.Next(0000, 9999);
            double three = rnd.Next(0000, 9999);
            double four = rnd.Next(0000, 9999);
            double Salt = rnd.Next(0000, 9999);
            string cardNumber = $"{one}{two}{three}{four}";
            user.CardNumber = cardNumber;
            user.Salt = $"{Salt}";
            user.Password = md5.HashPassword(password, user.Salt);
            user.CreatedAt = thisDay;
            user.UpdatedAt = thisDay;
            user.Status = 1;
            userModel.Store(user);
        }
        public User Login(string email,string password)
        {   
            UserModel userModel = new UserModel();
            User _user = userModel.Login(email, password);
            if (_user != null)
            {
                Console.WriteLine("login success\n");
                return _user;
            }
            else
            {
                Console.WriteLine("Login false");
                return null;
            }

        }
    }
}