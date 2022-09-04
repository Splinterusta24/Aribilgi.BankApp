using Aribilgi.BankApp.Web.Data.Contexts;
using Aribilgi.BankApp.Web.Data.Entities;
using Aribilgi.BankApp.Web.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Aribilgi.BankApp.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IRepository<ApplicationUser> _userRepo;
        private readonly IRepository<Account> _accountRepo;

        public AccountController(IRepository<ApplicationUser> userRepo, IRepository<Account> accountRepo)
        {
            _userRepo = userRepo;
            _accountRepo = accountRepo;
        }

        public IActionResult Index(int UserId)
        {
            ApplicationUser user = _userRepo.Get(x => x.Id == UserId);
            user.Accounts = _accountRepo.GetAll(x=> x.ApplicationUserId == UserId);

            return View(user);
        }

        [HttpPost]
        public IActionResult Create(Account account)
        {
            _accountRepo.Add(account);
            
            return RedirectToAction("Index","Home");
        }
    }
}
