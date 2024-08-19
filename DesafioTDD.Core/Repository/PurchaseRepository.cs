using DesafioTDD.Core.Interface;
using DesafioTDD.Core.Model;

namespace DesafioTDD.Core.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public Task AddPurchaseAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAllPurchasesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetPurchasesByClientIdAsync(Guid clientId)
        {
            throw new NotImplementedException();
        }
    }
}
