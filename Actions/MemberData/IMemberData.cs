using sacco.Models;
using sacco.Models.context;

namespace sacco.Actions.UserData
{
    public interface IMemberData
    {
        async Task AddMember(Member member,ApplicationDbContext _db) { }
       async  Task<Member> MemberFromDb(int Id, ApplicationDbContext _db) {
            var member = new Member();
                return member;
                }
        async Task<ICollection<Member>> allMembers(ApplicationDbContext _db)
        {
            var members = new List<Member>();
            return members;
        }
    }
}
