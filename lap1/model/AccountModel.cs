using System;
using lap1.entity;
using lap1.helper;
using MySqlConnector;

namespace lap1.model
{
    public class AccountModel
    {
        private ConnectionHelper connectionHelper = new ConnectionHelper();
        private User _user = null;

        public User Recharge(string account ,double money)
        {
            double sun = 0;
            MySqlConnection connection = connectionHelper.GetConnection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            try
            {
                cmd.CommandText = $"SELECT * from users WHERE email ='{account}'";
                MySqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    sun = double.Parse(data["balance"].ToString()) + money;
                    data.Close();
                }

                if (sun != 0)
                {
                    cmd.CommandText = $"UPDATE `users` SET `balance`='{sun}' WHERE email ='{account}'";
                    MySqlDataReader a = cmd.ExecuteReader();
                    Console.WriteLine($"\tSuccessful recharge {money}$ balance {sun}$");
                    a.Close();
                }
                cmd.CommandText = $"SELECT * from users WHERE email ='{account}'";
                MySqlDataReader dataUser = cmd.ExecuteReader();
                while (dataUser.Read())
                {
                    var first_name = dataUser["first_name"].ToString();
                    var last_name = dataUser["last_name"].ToString();
                    var email = dataUser["email"].ToString();
                    var pass = dataUser["password"].ToString();
                    var phone = dataUser["phone"].ToString();
                    var address = dataUser["address"].ToString();
                    var card_number = dataUser["card_number"].ToString();
                    var balance = Double.Parse(dataUser["balance"].ToString());
                    var salt = dataUser["salt"].ToString();
                    var status = int.Parse(dataUser["status"].ToString());
                    var created_at = DateTime.Parse(dataUser["created_at"].ToString());
                    var updated_at = DateTime.Parse(dataUser["updated_at"].ToString());
                    _user = new User(first_name, last_name, email, pass, phone, address, card_number,balance,salt,status,created_at,updated_at);
                }
                dataUser.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error!");
                throw;
            }
            return _user;
        }
        public User Withdrawal(string account ,double money)
        {
            double sun = 0;
            MySqlConnection connection = connectionHelper.GetConnection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            try
            {
                cmd.CommandText = $"SELECT * from users WHERE email ='{account}'";
                MySqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    sun = double.Parse(data["balance"].ToString()) - money;
                    data.Close();
                }

                if (sun != 0)
                {
                    cmd.CommandText = $"UPDATE `users` SET `balance`='{sun}' WHERE email ='{account}'";
                    MySqlDataReader a = cmd.ExecuteReader();
                    Console.WriteLine($"\tSuccessful recharge {money}$ balance {sun}$");
                    a.Close();
                }
                cmd.CommandText = $"SELECT * from users WHERE email ='{account}'";
                MySqlDataReader dataUser = cmd.ExecuteReader();
                while (dataUser.Read())
                {
                    var first_name = dataUser["first_name"].ToString();
                    var last_name = dataUser["last_name"].ToString();
                    var email = dataUser["email"].ToString();
                    var pass = dataUser["password"].ToString();
                    var phone = dataUser["phone"].ToString();
                    var address = dataUser["address"].ToString();
                    var card_number = dataUser["card_number"].ToString();
                    var balance = Double.Parse(dataUser["balance"].ToString());
                    var salt = dataUser["salt"].ToString();
                    var status = int.Parse(dataUser["status"].ToString());
                    var created_at = DateTime.Parse(dataUser["created_at"].ToString());
                    var updated_at = DateTime.Parse(dataUser["updated_at"].ToString());
                    _user = new User(first_name, last_name, email, pass, phone, address, card_number,balance,salt,status,created_at,updated_at);
                }
                dataUser.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error!");
                throw;
            }
            return _user;
        }

        public User Transfers(string account, double money, string receiver, double sun)
        {
            double total = 0;
            MySqlConnection connection = connectionHelper.GetConnection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            try
            {
                cmd.CommandText = $"SELECT * from users WHERE card_number ='{receiver}'";
                
                MySqlDataReader datareceiver = cmd.ExecuteReader();
                if (datareceiver.Read())
                {
                    Console.WriteLine($"are you sure you want to transfer the amount {money}$ Name {datareceiver["first_name"]} {datareceiver["last_name"]}  card number {datareceiver["card_number"]}");
                    Console.WriteLine("choose ◉ y confirm");
                    Console.WriteLine("choose ◉ n cancel");
                    string choice = Console.ReadLine();
                    total =  double.Parse(datareceiver["balance"].ToString()) + money;
                    string U = datareceiver["cardNumber"].ToString();
                    datareceiver.Close();
                    switch (choice)
                    {
                        case "y":
                           
                                if (U != null)
                                {
                                    cmd.CommandText = $"UPDATE `users` SET `balance`='{total}' WHERE card_number ='{receiver}'";
                                    MySqlDataReader a = cmd.ExecuteReader();
                                    a.Close();
                                    cmd.CommandText = $"UPDATE `users` SET `balance`='{sun}' WHERE email ='{account}'";
                                    MySqlDataReader y = cmd.ExecuteReader();
                                    y.Close();
                                    cmd.CommandText = $"SELECT * from users WHERE email ='{account}'";
                                    MySqlDataReader dataUser = cmd.ExecuteReader();
                                    while (dataUser.Read())
                                    {
                                        var first_name = dataUser["first_name"].ToString();
                                        var last_name = dataUser["last_name"].ToString();
                                        var email = dataUser["email"].ToString();
                                        var pass = dataUser["password"].ToString();
                                        var phone = dataUser["phone"].ToString();
                                        var address = dataUser["address"].ToString();
                                        var card_number = dataUser["card_number"].ToString();
                                        var balance = Double.Parse(dataUser["balance"].ToString());
                                        var salt = dataUser["salt"].ToString();
                                        var status = int.Parse(dataUser["status"].ToString());
                                        var created_at = DateTime.Parse(dataUser["created_at"].ToString());
                                        var updated_at = DateTime.Parse(dataUser["updated_at"].ToString());
                                        _user = new User(first_name, last_name, email, pass, phone, address, card_number,balance,salt,status,created_at,updated_at);
                                        Console.WriteLine("\tMoney transfer successful");
                                    }
                                    dataUser.Close();
                                }
                                datareceiver.Close();
                                break;
                        case "n":
                            Console.WriteLine("Cancel");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\tWrong account number!");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error!");
                throw;
            }
            return _user;

        }
    }
}