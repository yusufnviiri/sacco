using System.ComponentModel.Design;

namespace sacco.Models
{
    public class Account
    {
        public decimal Amount { get; set; } 
        public Member Member { get; set; }
        public decimal Balance { get; set; }
    }
}
