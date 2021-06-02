using System;

namespace lap1.entity
{
    public class Transaction
    {  
        public string Code { set; get; }
        /* stk nguoi gui*/
        public string SenderAccountNumber { set; get; }
        /* stk nguoi nhan */
        public string ReceiverAccountNumber { set; get; }
        
        public double Money { set; get; }
        
        public string Type { set; get; }
        
        public int Status { set; get; }
        
        public string Message { set; get; }
        
        public DateTime CreatedAt { set; get; }
        
        public DateTime UpdatedAt { set; get; }

        public Transaction()
        {
        }

        public Transaction(string code, string senderAccountNumber, string receiverAccountNumber, double money, string type, int status, string message, DateTime createdAt, DateTime updatedAt)
        {
            Code = code;
            SenderAccountNumber = senderAccountNumber;
            ReceiverAccountNumber = receiverAccountNumber;
            Money = money;
            Type = type;
            Status = status;
            Message = message;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}