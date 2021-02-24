using System;
using System.ComponentModel.DataAnnotations;

namespace ATMWeb.Domain
{
    public class AccountTransaction
    {
        public AccountTransaction() { }

        [Key]
        public int TranId { get; set; }
        public int AcctId { get; set; }
        public int TransactionType { get; set; }

        public double TransactionAmount { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
