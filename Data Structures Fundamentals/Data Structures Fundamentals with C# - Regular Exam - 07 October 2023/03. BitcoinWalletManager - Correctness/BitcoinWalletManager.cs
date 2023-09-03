using System;
using System.Collections.Generic;

namespace BitcoinWalletManagementSystem
{
    using System.Linq;

    public class BitcoinWalletManager : IBitcoinWalletManager
    {
        private Dictionary<string, Transaction> transactions;
        private Dictionary<string, Wallet> wallets;
        private Dictionary<string, User> users;

        public BitcoinWalletManager()
        {
            this.transactions = new Dictionary<string, Transaction>();
            this.wallets = new Dictionary<string, Wallet>();
            this.users = new Dictionary<string, User>();
        }

        public void CreateUser(User user)
        {
            this.users.TryAdd(user.Id, user);
        }

        public void CreateWallet(Wallet wallet)
        {
            if (!this.wallets.ContainsKey(wallet.Id))
            {
                this.wallets.Add(wallet.Id, wallet);
                this.users[wallet.UserId].Wallets.Add(wallet);
            }
        }

        public bool ContainsUser(User user)
            => this.users.ContainsKey(user.Id);

        public bool ContainsWallet(Wallet wallet)
            =>  this.wallets.ContainsKey(wallet.Id);

        public IEnumerable<Wallet> GetWalletsByUser(string userId)
            => this.users[userId].Wallets;

        public void PerformTransaction(Transaction transaction)
        {
            if (!this.wallets.ContainsKey(transaction.ReceiverWalletId) ||
                !this.wallets.ContainsKey(transaction.SenderWalletId) ||
                !this.users.ContainsKey(this.wallets[transaction.ReceiverWalletId].UserId) ||
                !this.users.ContainsKey(this.wallets[transaction.SenderWalletId].UserId) ||
                this.users[this.wallets[transaction.SenderWalletId].UserId].Wallets.First(w => w.Id == transaction.SenderWalletId).Balance < transaction.Amount)
            {
                throw new ArgumentException();
            }

            this.transactions.Add(transaction.Id, transaction);
            this.users[this.wallets[transaction.SenderWalletId].UserId].Transactions.Add(transaction);
            this.users[this.wallets[transaction.ReceiverWalletId].UserId].Transactions.Add(transaction);
        }

        public IEnumerable<Transaction> GetTransactionsByUser(string userId)
            => this.users[userId].Transactions;

        public IEnumerable<Wallet> GetWalletsSortedByBalanceDescending()
            => this.wallets.Values
                .OrderByDescending(w => w.Balance);

        public IEnumerable<User> GetUsersSortedByBalanceDescending()
            => this.users.Values
                .OrderByDescending(u => u.Wallets.Sum(w => w.Balance));

        public IEnumerable<User> GetUsersByTransactionCount()
            => this.users.Values
                .OrderByDescending(u => u.Transactions.Count);
    }
}