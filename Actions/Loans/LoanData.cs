using sacco.Models.context;
using sacco.Models;
using sacco.Actions.Savings;
namespace sacco.Actions.Loans
{
   
    public class LoanData : ILoanData
    {
        private readonly Saving _savings=new();
        public Member member { get; set; } = new Member();
        public ODataManager ODataManager { get; set; }= new ODataManager();
        public Deposit deposit { get; set; } = new Deposit();

        public IEnumerable<Deposit> deposits { get; set; } = Enumerable.Empty<Deposit>();
        public async Task<ODataManager> newLoan(ApplicationDbContext _db, int Id)
        {
            member = await _db.Members.FindAsync(Id);
            ODataManager.MemberId = Id;
            deposit = await _savings.GetLastMemberDeposit(_db, Id,ODataManager);
            if (deposit != null)
            {
                if (deposit.Balance < 1000M)
                {
                    return ODataManager;
                }
                else
                {
                    ODataManager.Member = member;

                    ODataManager.RequestStatus = true;
                }
            }
            return ODataManager;
        }
      public Loan CalculateInterest(Loan loan)
        {
            loan.totalPayment = loan.Amount * loan.installments*loan.interest;
            loan.installmentAmount = (decimal)Math.Floor(loan.totalPayment / loan.installments);
            return loan;
        }

        public async Task saveLoan(ApplicationDbContext _db, ODataManager data)
        {
            member = await _db.Members.FindAsync(data.MemberId);

            data.Loan.Member = member;
            CalculateInterest(data.Loan);
            await _db.Loans.AddAsync(data.Loan);
            await _db.SaveChangesAsync();

        }
    }
}
