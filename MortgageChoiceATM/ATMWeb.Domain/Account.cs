using System;
using System.ComponentModel.DataAnnotations;

namespace ATMWeb.Domain
{
    public class Account
    {
        public Account() { }

        [Key]
        public int AcctId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(10)]
        public string AccountNumber { get; set; }
        
        public string AccountPIN { get; set; }

        public int AccountType { get; set; }

        public int AccountStatus { get; set; }
        public double InitialAmountDeposit { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
