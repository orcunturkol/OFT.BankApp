﻿using OFT.BankApp.Web.Data.Entitites;
using OFT.BankApp.Web.Models;

namespace OFT.BankApp.Web.Mapping
{
    public class AccountMapper : IAccountMapper
    {
        public Account Map(AccountCreateModel model) {
            return new Account
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance
            };
        }
    }
}
