using System;
using System.Collections.Generic;
using lap1.entity;
using lap1.helper;
using MySqlConnector;

namespace lap1.model
{
    public class TransactionModel
    {
        private ConnectionHelper connectionHelper = new ConnectionHelper();
        public void Store (Transaction transaction)
        {
            MySqlConnection connection = connectionHelper.GetConnection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            try
            {
                cmd.CommandText =
                    "INSERT INTO `transactions`(`Code`, `SenderAccountNumber`, `ReceiverAccountNumber`, `Money`, `Type`, `Status`, `Message`, `CreatedAt`, `UpdatedAt`) VALUES (?Code,?SenderAccountNumber,?ReceiverAccountNumber,?Money,?Type,?Status,?Message,?CreatedAt,?UpdatedAt,";
                cmd.Parameters.Add("?Code", MySqlDbType.VarChar).Value = transaction.Code;
                cmd.Parameters.Add("?SenderAccountNumber", MySqlDbType.VarChar).Value = transaction.SenderAccountNumber;
                cmd.Parameters.Add("?ReceiverAccountNumber", MySqlDbType.VarChar).Value = transaction.ReceiverAccountNumber;
                cmd.Parameters.Add("?Money", MySqlDbType.VarChar).Value = transaction.Money;
                cmd.Parameters.Add("?Type", MySqlDbType.VarChar).Value = transaction.Type;
                cmd.Parameters.Add("?Status", MySqlDbType.VarChar).Value = transaction.Status;
                cmd.Parameters.Add("?Message", MySqlDbType.VarChar).Value = transaction.Message;
                cmd.Parameters.Add("?CreatedAt", MySqlDbType.VarChar).Value = transaction.CreatedAt;
                cmd.Parameters.Add("?UpdatedAt", MySqlDbType.VarChar).Value = transaction.UpdatedAt;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("error");
                throw;
            }
        }
        public List<Transaction> TransactionHistory (string AccountNumber)
        {
            
            MySqlConnection connection = connectionHelper.GetConnection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            List<Transaction> transactionslist = new List<Transaction>();
            try
            {
                cmd.CommandText =
                    $"SELECT * FROM `transactions` WHERE SenderAccountNumber = '{AccountNumber}' OR ReceiverAccountNumber = '{AccountNumber}'";
                MySqlDataReader data= cmd.ExecuteReader();
                while (data.Read())
                {
                    Transaction transaction = new Transaction(data["Code"].ToString(),data["SenderAccountNumber"].ToString(),data["ReceiverAccountNumber"].ToString(),double.Parse(data["Money"].ToString()),data["Type"].ToString(),int.Parse(data["Status"].ToString()),data["Message"].ToString(),DateTime.Parse(data["CreatedAt"].ToString()),DateTime.Parse(data["UpdatedAt"].ToString()));
                    transactionslist.Add(transaction);
                }
                data.Close();
                return transactionslist;
            }
            catch (Exception e)
            {
                Console.WriteLine("error");
                throw;
            }
        }
    }
}