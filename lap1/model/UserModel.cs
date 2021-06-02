using System;
using lap1.entity;
using lap1.helper;
using MySqlConnector;

namespace lap1.model
{
    public class UserModel
    {
        private ConnectionHelper connectionHelper = new ConnectionHelper();
        private User _user = null;

        public void Store(User user)
        {
            MySqlConnection connection = connectionHelper.GetConnection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            try
            {
                cmd.CommandText =
                    "INSERT INTO `users`(`first_name`,`last_name`, `email`, `password`, `phone`, `address`, `status`, `card_number`, `created_at`, `updated_at`, `salt`) VALUES (?first_name, ?last_name, ?email, ?password, ?phone, ?address, ?status, ?card_number, ?created_at, ?updated_at, ?salt)";
                cmd.Parameters.Add("?first_name", MySqlDbType.VarChar).Value = user.FirstName;
                cmd.Parameters.Add("?last_name", MySqlDbType.VarChar).Value = user.LastName;
                cmd.Parameters.Add("?email", MySqlDbType.VarChar).Value = user.Email;
                cmd.Parameters.Add("?password", MySqlDbType.VarChar).Value = user.Password;
                cmd.Parameters.Add("?phone", MySqlDbType.VarChar).Value = user.Phone;
                cmd.Parameters.Add("?address", MySqlDbType.VarChar).Value = user.Address;
                cmd.Parameters.Add("?status", MySqlDbType.VarChar).Value = user.Status;
                cmd.Parameters.Add("?card_number", MySqlDbType.VarChar).Value = user.CardNumber;
                cmd.Parameters.Add("?created_at", MySqlDbType.VarChar).Value = user.CreatedAt;
                cmd.Parameters.Add("?updated_at", MySqlDbType.VarChar).Value = user.UpdatedAt;
                cmd.Parameters.Add("?salt", MySqlDbType.VarChar).Value = user.Salt;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Create user success");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Create user error");
                throw;
            }
        }

        public User Login(string account, string password)
        {
            Md5 md5 = new Md5();
            MySqlConnection connection = connectionHelper.GetConnection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            try
            {
                string hashPassword = null;
                cmd.CommandText = $"SELECT * from users WHERE email ='{account}'";
                MySqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    data.Read();
                    hashPassword = md5.HashPassword(password, data["Salt"].ToString());
                    string pw = data["password"].ToString();
                    data.Close();
                    if (hashPassword.Equals(pw))
                    {
                        cmd.CommandText = $"SELECT * from users WHERE password ='{hashPassword}'";
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
                    return _user;
                }
                else
                {
                    data.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error");
                throw;
            }
        }
    }
}