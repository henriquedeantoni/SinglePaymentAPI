using SinglePaymentAPI.Models.Enum;

namespace SinglePaymentAPI.Models
{
    public class WalletEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string SSNorEIN { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public UserType UserType { get; set; }

        private WalletEntity() { }
        public WalletEntity(int id, string name, string sSNorEIN, string email, string password, decimal balance, UserType userType)
        {
            Id = id;
            Name = name;
            SSNorEIN = sSNorEIN;
            Email = email;
            Password = password;
            Balance = balance;
            UserType = userType;
        }

        public void DebitToBalance(decimal value)
        {
            Balance -= value;
        }

        public void CreditToBalance(decimal value)
        {
            Balance += value;
        }
    }
}
