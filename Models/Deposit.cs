using System.ComponentModel.DataAnnotations.Schema;

namespace sacco.Models
{
    public class Deposit:Account
    {
        public int DepositId { get; set; }
        [ForeignKey("Depositor")]
        public Member Member { get; set; }
    }
}
