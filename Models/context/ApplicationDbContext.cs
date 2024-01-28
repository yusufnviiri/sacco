using System.Xml.Serialization;


using Microsoft.EntityFrameworkCore;

namespace sacco.Models.context
{
    public class ApplicationDbContext:DbContext
    {
      
        //configure context
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        }
}
