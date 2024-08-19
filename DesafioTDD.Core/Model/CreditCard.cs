namespace DesafioTDD.Core.Model
{
    public class CreditCard
    {
        public string CardNumber { get; set; } = string.Empty;
        public string CardHolderName { get; set; } = string.Empty;
        public int Value { get; set; }
        public int CVV { get; set; }
        public string ExpDate { get; set; } = string.Empty;
    }
}
