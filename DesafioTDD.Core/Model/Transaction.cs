namespace DesafioTDD.Core.Model
{
    public class Transaction
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public int TotalToPay { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
