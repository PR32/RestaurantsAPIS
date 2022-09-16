using RestaurantsAPIS.Model;
using System.Collections.Generic;

namespace RestaurantsAPIS.IService
{
    public interface IProductsService
    {
        public List<Product> GetProducts();

        public Product AddProduct(Product productItem);

        public Product UpdateProduct(string id, Product productItem);

        public string DeleteProduct(string id);
    }
}
