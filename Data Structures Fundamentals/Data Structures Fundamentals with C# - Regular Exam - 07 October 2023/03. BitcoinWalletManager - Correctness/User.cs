namespace BitcoinWalletManagementSystem
{
    using System.Collections.Generic;

    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<Wallet> Wallets = new List<Wallet>();

        public List<Transaction> Transactions = new List<Transaction>();
    }
}