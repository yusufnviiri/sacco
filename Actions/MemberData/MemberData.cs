using Microsoft.EntityFrameworkCore;
using sacco.Models;
using sacco.Models.context;

namespace sacco.Actions.UserData
{
    public class MemberData:IMemberData
    {
        public async Task AddMember(Member member, ApplicationDbContext _db) {
            if (member == null) { throw new ArgumentNullException("member"); } else
            {
               await _db.Members.AddAsync(member);
                await _db.SaveChangesAsync();
            }
        
        }
        public async Task<Member> MemberFromDb(int Id, ApplicationDbContext _db)
        {
            var member = await _db.Members.ToListAsync();
            return member.FirstOrDefault();
        }
        public async Task<ICollection<Member>>allMembers(ApplicationDbContext _db)
        {
            var members = await _db.Members.ToListAsync();
            return members;
        }
    }
}
