    namespace MoneySplitterApi.Models
    {
        public class Debts
        {
            public Guid Id { get; set; }
            public string  Description { get; set; }
            public decimal Amount { get; set; }
            public DateTime DateOwed { get; set; }
            public DateTime DeadLine { get; set; }
            public bool IsPaid { get; set; }
            public string Creditor { get; set; }
            public string Debtor { get; set; }
        }
    }
