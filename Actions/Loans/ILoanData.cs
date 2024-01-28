using sacco.Models.context;
using sacco.Models;

namespace sacco.Actions.Loans
{
    public interface ILoanData
    {
        async Task<ODataManager> newLoan(ApplicationDbContext _db, int Id)
        {             return new ODataManager();
        }
        async Task saveLoan(ApplicationDbContext _db, ODataManager data)
        {
        }
        Loan CalculateInterest(Loan loan) {
            return new Loan();
        }
    }
}
