using Microsoft.AspNetCore.Mvc;
using sacco.Actions.Loans;
using sacco.Actions.Savings;
using sacco.Actions.UserData;
using sacco.Models;
using sacco.Models.context;


namespace sacco.Controllers
{
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly MemberData _memberdata = new();
        public readonly Saving _savings = new ();
        public readonly LoanData _loanData = new();
        public ODataManager ODataManager { get; set; } = new();

        public MemberController(ApplicationDbContext db)
        {
            _db = db;

        }      
    
        [BindProperty]
       public Member Member { get; set; }
        public async Task<IActionResult> Create()
        {
            Member member = new Member();
            return View(member);
        }
        [HttpPost]
        // create a new member
        public async Task<IActionResult> Create(Member member )
        {
            await _memberdata.AddMember(member, _db);

            return RedirectToAction("Create");
        }
        //get all members
        public async Task<IActionResult> Index()
        {
          var members =  await _memberdata.allMembers(_db);
            return View(members);
        }
        //create account view
        public async Task<IActionResult> CreateAccount(int Id)
        {
           var odatamanager =await  _savings.memberToDeposit(_db, Id);
            return View(odatamanager);
        }
        [HttpPost]
        //save member deposits into db
        public async Task<IActionResult> CreateAccount(ODataManager data)
        {
           await  _savings.memberDeposits(_db, data);

            return RedirectToAction("index");
        
        }
        //Loan Application View
        public async Task<IActionResult> LoanApplication(int Id)
        {
            ODataManager = await _loanData.newLoan(_db, Id);
            if (ODataManager.RequestStatus == true)
            {
                return View(ODataManager);
            }                

            return RedirectToAction("index");

        }
        //save loan
        [HttpPost]
        public async Task<IActionResult> LoanApplication(ODataManager data)
        {
            await _loanData.saveLoan(_db, data);
            return RedirectToAction("index");

        }
        public async Task<IActionResult> Withdraw()
        {
            return View(ODataManager);

        }

    }
}
