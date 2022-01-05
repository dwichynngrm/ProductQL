using ProductQL.Models;

namespace ProductQL.GraphQL
{
    public class AddProductPayload
    {
        public AddProductPayload(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }
}
