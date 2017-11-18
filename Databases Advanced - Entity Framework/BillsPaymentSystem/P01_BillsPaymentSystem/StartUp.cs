using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Data.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace P01_BillsPaymentSystem
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            BillsPaymentSystemContext db = new BillsPaymentSystemContext();

            using (db)
            {
                db.Database.EnsureDeleted();
                db.Database.Migrate();

                Seed(db);

                UserAccountsDetails(db);

                CalculatePayBills(db);

            }

        }

        private static void CalculatePayBills(BillsPaymentSystemContext db)
        {
            Console.Write("Enter PayBill UserId : ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("Enter Ammount : ");
            decimal amount = decimal.Parse(Console.ReadLine());

            try
            {
                PayBills(userId, amount, db);
                Console.WriteLine("Successful Payment");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        private static void PayBills(int userId, decimal amount, BillsPaymentSystemContext db)
        {
            User user = db.Users.Find(userId);

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
                return;
            }

            var bankAccounts = db.BankAccounts.Join
                (
                    db.PePaymentMethods,
                    (ba => ba.BankAccountId),
                    (pm => pm.BankAccountId),
                    (ba, pm) => new
                    {
                        Id = pm.BankAccountId,
                        Balance = ba.Balance,
                        Bank = ba.BankName,
                        Swift = ba.SWIFT
                    })
                .Where(pm => pm.Id == userId)
                .OrderBy(pm => pm.Id)
                .ToList();

            var creditCards = db.CreditCards.Join
                (
                    db.PePaymentMethods,
                    (cc => cc.CreditCardId),
                    (pm => pm.CreditCardId),
                    (cc, pm) => new
                    {
                        Id = pm.UserId,
                        Limit = cc.Limit,
                        MoneyOwned = cc.MoneyOwed,
                        LimitLeft = cc.LimitLeft,
                        ExDate = cc.ExpirationDate
                    }
                )
                .Where(pm => pm.Id == userId)
                .OrderBy(pm => pm.Id)
                .ToList();

            decimal totalUserMoney = creditCards.Sum(m => m.MoneyOwned) + bankAccounts.Sum(m => m.Balance);

            if (totalUserMoney < amount)
            {
                throw new InvalidOperationException("Insufficient funds!");
            }


            bool isPayBills = false;

            foreach (var account in bankAccounts)
            {
                BankAccount currentAccount = db.BankAccounts.Find(account.Id);

                if (amount <= currentAccount.Balance)
                {
                    currentAccount.Withdraw(amount);
                    isPayBills = true;
                }
                else
                {
                    amount -= currentAccount.Balance;
                    currentAccount.Withdraw(currentAccount.Balance);
                }

                if (isPayBills)
                {
                    db.SaveChanges();
                    return;
                }
            }

            foreach (var card in creditCards)
            {
                CreditCard currentCard = db.CreditCards.Find(card.Id);

                if (amount <= currentCard.LimitLeft)
                {
                    currentCard.Withdraw(amount);
                    isPayBills = true;
                }
                else
                {
                    amount -= currentCard.LimitLeft;
                    currentCard.Withdraw(currentCard.LimitLeft);
                }
                if (isPayBills)
                {
                    db.SaveChanges();
                    return;
                }
            }


        }

        private static void UserAccountsDetails(BillsPaymentSystemContext db)
        {
            Console.Write("Enter UserId : ");
            int userId = int.Parse(Console.ReadLine());

            User user = db.Users.Find(userId);

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
                return;
            }


            var bankAccounts = db.BankAccounts
                .Include(ba => ba.PaymentMethod)
                .ThenInclude(pm => pm.User)
                .Select(e => new


                {
                    Id = e.PaymentMethod.UserId,
                    Balance = e.Balance,
                    Bank = e.BankName,
                    Swift = e.SWIFT
                }
                )
                .Where(e => e.Id == userId)
                .ToList();


            var creditCards = db.CreditCards
                .Include(cc => cc.PaymentMethod)
                .ThenInclude(pm => pm.User)
                .Select(e => new
                {
                    Id = e.PaymentMethod.UserId,
                    Limit = e.Limit,
                    MoneyOwned = e.MoneyOwed,
                    LimitLeft = e.LimitLeft,
                    ExDate = e.ExpirationDate
                })
                .Where(e => e.Id == userId)
                .ToList();





            Console.WriteLine($"User: {user.FirstName} {user.LastName}");
            Console.WriteLine("Bank Accounts: ");

            foreach (var account in bankAccounts)
            {
                Console.WriteLine($" -- ID: {account.Id}");
                Console.WriteLine($" --- Balance: {account.Balance}");
                Console.WriteLine($" --- Bank: {account.Bank}");
                Console.WriteLine($" --- SWIFT: {account.Swift}");
            }

            Console.WriteLine($"Credit Cards:");

            foreach (var card in creditCards)
            {
                Console.WriteLine($" -- ID: {card.Id}");
                Console.WriteLine($" --- Limit: {card.Limit}");
                Console.WriteLine($" --- Money Owed: {card.MoneyOwned}");
                Console.WriteLine($" --- Limit Left: {card.LimitLeft}");
                Console.WriteLine($" --- Expiration Date: {card.ExDate}");
            }

        }

        private static void Seed(BillsPaymentSystemContext db)
        {
            List<User> users = new List<User>
           {
               new User
               {
                   FirstName = "Patar",
                   LastName = "Ivanov",
                   Email = "petar_ivanov@abv.bg",
                   Password = "123456789"

               },
               new User
               {
                   FirstName = "Stefan",
                   LastName = "Petrov",
                   Email = "stefan_petrov@abv.bg",
                   Password = "0254133677"
               },
               new User
               {
                   FirstName = "Gogo",
                   LastName = "Uzunov",
                   Email = "gogo_uzunov@abv.bg",
                   Password = "0251234447"
               }

           };

            db.Users.AddRange(users);

            db.SaveChanges();

            List<BankAccount> bankAccounts = new List<BankAccount>
            {
                new BankAccount
                {
                    Balance = 1000,
                    BankName = "Bank Of America",
                    SWIFT = "BOA"
                },
                new BankAccount
                {
                    Balance = 1200,
                    BankName = "Rottshield",
                    SWIFT = "ROTT"
                },
                new BankAccount
                {
                    Balance = 1300,
                    BankName = "JP Morgan",
                    SWIFT = "JPM"
                }

            };
            db.BankAccounts.AddRange(bankAccounts);

            db.SaveChanges();

            List<CreditCard> creditCards = new List<CreditCard>
            {
                new CreditCard
                {
                    ExpirationDate = new DateTime(2016,8,3),
                    Limit = 1800,
                    MoneyOwed = 600
                },
                new CreditCard
                {
                    ExpirationDate = new DateTime(2017,12,21),
                    Limit = 2000,
                    MoneyOwed = 700
                },
                new CreditCard
                {
                    ExpirationDate = new DateTime(2014,3,18),
                    Limit = 1200,
                    MoneyOwed = 380
                },

            };

            db.AddRange(creditCards);

            db.SaveChanges();

            List<PaymentMethod> paymentMethods = new List<PaymentMethod>
            {
                new PaymentMethod
                {
                    BankAccountId = 1,
                    UserId = 2,
                    Type = PaymentMethodType.BankAccount
               },
                new PaymentMethod
                {
                    BankAccountId = 2,
                    UserId = 3,
                    Type = PaymentMethodType.BankAccount
                },
                new PaymentMethod
                {
                    CreditCardId = 2,
                    UserId = 1,
                    Type = PaymentMethodType.CreditCard
                },
                new PaymentMethod
                {
                    CreditCardId = 3,
                    UserId = 2,
                    Type =  PaymentMethodType.CreditCard

                }
            };

            db.AddRange(paymentMethods);
            db.SaveChanges();
        }
    }
}
