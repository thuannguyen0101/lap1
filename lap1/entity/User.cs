using System;

namespace lap1.entity
{
    public class User
    {
        public string FirstName{ set; get; }
        public string LastName{ set; get; }
        public string Email{ set; get; }
        public string Password{ set; get; }
        public string Phone{ set; get; }
        public string Address{ set; get; }
        public string CardNumber{ set; get; }
        public double Balance{ set; get; }
        public string Salt{ set; get; }
        public int Status{ set; get; } 
        public DateTime DeletedAt{ set; get; } 
        public DateTime CreatedAt{ set; get; } 
        public DateTime UpdatedAt{ set; get; }

        public User()
        {
        }

        public User(string firstName, string lastName, string email, string password, string phone, string address, string cardNumber, double balance, string salt, int status, DateTime createdAt, DateTime updatedAt)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Phone = phone;
            Address = address;
            CardNumber = cardNumber;
            Balance = balance;
            Salt = salt;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}