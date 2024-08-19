using DesafioTDD.Core.Model;

namespace DesafioTDD.Core.Interface
{
    public interface IPurchaseRepository
    {
        Task AddPurchaseAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAllPurchasesAsync();
        Task<IEnumerable<Transaction>> GetPurchasesByClientIdAsync(Guid clientId);
    }
}
