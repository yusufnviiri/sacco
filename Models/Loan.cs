namespace sacco.Models
{
    public class Loan : Account
    {public int loanId { get; set; }
        public int installments { get; set; }
        public decimal installmentAmount { get; set; }
        public decimal interest { get; set; } = 0.12M;
         public decimal totalPayment { get; set; }

    }
}
