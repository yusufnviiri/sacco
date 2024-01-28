using Microsoft.EntityFrameworkCore;
using sacco.Models;
using sacco.Models.context;

namespace sacco.Actions.Savings
{
    public class Saving:ISavings
    {
        public ODataManager ODataManager { get; set; } = new ODataManager();
        public Member member = new Member();
        public Deposit deposit = new Deposit();
        public List<Deposit> deposits= new List<Deposit>();
        public decimal balance =0;
        public async Task<ODataManager> memberToDeposit(ApplicationDbContext _db, int Id)
        { 
            deposits = await _db.Deposits.Include(k=>k.Member).Where(p=>p.Member.memberId==Id).ToListAsync();
            if (deposits.Count > 0)
            {
                deposit = deposits.LastOrDefault();
                member = await _db.Members.FindAsync(deposit.Member.memberId);
                ODataManager.Deposit = new Deposit();
                ODataManager.Deposit.Balance = deposit.Balance;

            }
            else
            {
                member = await _db.Members.FindAsync(Id);
                ODataManager.Deposit = new Deposit();


            }
            ODataManager.Member = member;
            ODataManager.MemberId = member.memberId;
            return ODataManager;
        }
        public async Task memberDeposits(ApplicationDbContext _db,  ODataManager data)
        {
            member = await _db.Members.FindAsync(data.MemberId);
            // get last member deposit 
            deposits = await _db.Deposits.Where(k=>k.Member.memberId==data.MemberId).ToListAsync();
            if(deposits.Count()==0) {
                data.Deposit.Member = member;
                data.Deposit.Balance = data.Deposit.Amount;
                await _db.Deposits.AddAsync(data.Deposit);
                await _db.SaveChangesAsync();           
            
            } else
            {
            deposit =    await GetLastMemberDeposit(_db, member.memberId,data) ;
                deposit.Balance += data.Deposit.Balance;
               data.Deposit.Member = member;
                deposit.Amount = data.Deposit.Amount;
                data.Deposit.Balance= deposit.Balance+data.Deposit.Amount;
                await _db.Deposits.AddAsync(data.Deposit);
                await _db.SaveChangesAsync();         
            }



        }
       public async Task<Deposit> GetLastMemberDeposit(ApplicationDbContext _db, int Id,ODataManager data)
        {
            deposits = await _db.Deposits.Where(k => k.Member.memberId == data.MemberId).ToListAsync();
            deposit = deposits.LastOrDefault();
            return deposit;
        }


    }
}
