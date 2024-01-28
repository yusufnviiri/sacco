using sacco.Actions.Savings;

namespace sacco.Models
{
    public class ODataManager
    {
        public Deposit Deposit { get; set; } = new Deposit();   
        public Member Member { get; set; } = new Member();
        public int MemberId { get; set; }
        public Loan Loan { get; set; } = new Loan();
        public bool RequestStatus { get; set; } = false;
    }
}
