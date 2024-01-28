using System.ComponentModel.DataAnnotations.Schema;

namespace sacco.Models
{
    public class Member:Person
    {
        public int memberId { get;set; }
        public int DepositId { get;set; }
        public List<Deposit>? Deposits { get; set; } = new List<Deposit>();
    }
}
