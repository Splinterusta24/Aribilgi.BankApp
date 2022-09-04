using Aribilgi.BankApp.Web.Data.Contexts;
using Aribilgi.BankApp.Web.Data.Entities;
using Aribilgi.BankApp.Web.Data.Enums;
using Aribilgi.BankApp.Web.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Aribilgi.BankApp.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IRepository<ApplicationUser> _userRepo;
        private readonly IRepository<Account> _accountRepo;
        private readonly IRepository<Transaction> _transactionRepo;

        public AccountController(IRepository<ApplicationUser> userRepo, IRepository<Account> accountRepo, IRepository<Transaction> transactionRepo)
        {
            _userRepo = userRepo;
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
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
        [HttpPost]
        public IActionResult SendMoney(int fromAccount, int toAccount, decimal amount)
        {
            Account _fromAccount = _accountRepo.Get(x => x.Id == fromAccount );
            Account _toAccount = null;
            if(_fromAccount.Balance < amount)
            {
                return View(false);
            }
            if (!_accountRepo.Any(x => x.AccountNumber == toAccount))
            {
                return View(false);

            }
            _toAccount = _accountRepo.Get(x => x.AccountNumber == toAccount);
            _fromAccount.Balance -= amount;

            _accountRepo.Update(_fromAccount);

            Transaction transaction = new();
            transaction.FromAccountId = _fromAccount.Id;
            transaction.ToAccountId = _toAccount.Id;
            transaction.TransactionTime = DateTime.Now;
            transaction.Statu = TransactionStatu.Beklemede;
            transaction.Amount = amount;

            _transactionRepo.Add(transaction);

            return RedirectToAction("Index", "Home");



     

        }
    }
}
