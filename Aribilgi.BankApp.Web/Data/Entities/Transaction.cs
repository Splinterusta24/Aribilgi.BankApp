using Aribilgi.BankApp.Web.Data.Enums;
using System;

namespace Aribilgi.BankApp.Web.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public TransactionStatu Statu { get; set; }
        public DateTime TransactionTime { get; set; }

        //public Account FromAccount { get; set; } //navigation prop.


    }
}
