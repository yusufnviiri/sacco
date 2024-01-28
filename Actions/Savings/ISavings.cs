using sacco.Models;
using sacco.Models.context;

namespace sacco.Actions.Savings
{
    public interface ISavings
    {
        async Task<ODataManager> memberToDeposit(ApplicationDbContext _db,int Id)
        {
            return new ODataManager();
        }
        async Task memberDeposits(ApplicationDbContext _db, int Id,ODataManager data)
        {
        }
        async Task<Deposit> GetLastMemberDeposit(ApplicationDbContext _db, int Id,ODataManager data)
        {
            return new Deposit();
        }



    }
}
