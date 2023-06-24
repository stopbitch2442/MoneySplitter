namespace MoneySplitterApi.Models
{
    public class Ledgers
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool Sign { get; set; } // Знак (+ или -)
        
    }
}
