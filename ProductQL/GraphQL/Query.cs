using HotChocolate;
using HotChocolate.Types;
using ProductQL.Models;
using System.Linq;

namespace ProductQL.GraphQL
{
    public class Query
    {
        public IQueryable<User> GetUsers([Service] ProductQLContext context) =>
        context.Users;
        public IQueryable<User> GetUserById(int id, [Service] ProductQLContext context) =>
             context.Users.Where(t => t.Id == id).AsQueryable();
        public IQueryable<Product> GetProducts([Service] ProductQLContext context) =>
       context.Products;

        public IQueryable<Product> GetProductById(int id, [Service] ProductQLContext context) =>
             context.Products.Where(t => t.Id == id).AsQueryable();
    }
}
