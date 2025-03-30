namespace SinglePaymentAPI.Models
{
    public class TransferEntity
    {
        public Guid IdTransaction { get; set; }
        public int SenderId { get; set; }
        public WalletEntity Sender { get; set; }

        public int ReceiverId { get; set; }
        public WalletEntity Receiver { get; set; }
        public decimal Value { get; set; }

        public TransferEntity(int senderId, int receiverId, decimal value)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Value = value;
        }
    }
}
