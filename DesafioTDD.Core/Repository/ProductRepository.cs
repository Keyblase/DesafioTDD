using DesafioTDD.Core.Interface;
using DesafioTDD.Core.Model;

namespace DesafioTDD.Core.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void AddProductAsync(Product product)
        {
            
        }

        public IEnumerable<Product> GetProductsAsync()
        {
            return
            [
                new Product(){ 
                Title = "Blusa do Imperio",
                Price = 78,
                Zipcode = "78993-000",
                Seller = "Nicolas",
                ThumbnailHd = "https://cdn.awsli.com.br/600x450/21/21351/produto/3853007/f66e8c63ab.jpg",
                Date = "26/11/2015"
                },
                new Product(){
                Title = "Blusa do Imperio 2",
                Price = 73,
                Zipcode = "73993-000",
                Seller = "Nicolas 2",
                ThumbnailHd = "https://cdn.awsli.com.br/600x450/21/21351/produto/3853007/f66e8c63ab.jpg",
                Date = "26/11/2015"
                }
            ];
        }
    }
}
