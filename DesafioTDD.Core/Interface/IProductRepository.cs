using DesafioTDD.Core.Model;

namespace DesafioTDD.Core.Interface
{
    public interface IProductRepository
    {
        void AddProductAsync(Product product);
        IEnumerable<Product> GetProductsAsync();
    }
}
