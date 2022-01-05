using HotChocolate;
using ProductQL.Models;
using System.Threading.Tasks;
using System.Linq;
using ProductQL.GraphQL;
using System;

namespace ProductQL.GraphQL
{
    public class Mutation
    {
        public async Task<AddUserPayload> AddUserAsync(
        AddUserInput input,
        [Service] ProductQLContext context)
        {
            var user = new User
            {
                
                FullName = input.FullName,
                Email = input.Email,
                Username = input.Username,
                Password = input.Password
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return new AddUserPayload(user);
        }


        public async Task<AddUserPayload> UpdateUserAsync(int id,
        AddUserInput input,
        [Service] ProductQLContext context)
        {
            var result = context.Users.Where(c => c.Id == id).FirstOrDefault();
            if (result != null)
            {
                result.FullName = input.FullName;
                result.Email = input.Email;
                result.Username = input.Username;
                result.Password = input.Password;
                await context.SaveChangesAsync();
            }

            return new AddUserPayload(result);
        }


        public async Task<AddUserPayload> DeleteUserAsync(int id,
        [Service] ProductQLContext context)
        {
            var result = context.Users.Where(c => c.Id == id).FirstOrDefault();
            if (result != null)
            {
                context.Users.Remove(result);
                await context.SaveChangesAsync();
            }

            return new AddUserPayload(result);
        }


        public async Task<AddProductPayload> AddProductAsync(
        AddProductInput input,
        [Service] ProductQLContext context)
        {
            var product = new Product
            {

                Name = input.Name,
                Stock = input.Stock,
                Price = input.Price,
                Created = System.DateTime.Now

            };

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return new AddProductPayload(product);
        }


        public async Task<AddProductPayload> UpdateProductAsync(int id,
       AddProductInput input,
       [Service] ProductQLContext context)
        {
            var result = context.Products.Where(c => c.Id == id).FirstOrDefault();
            if (result != null)
            {
                result.Name = input.Name;
                result.Stock = input.Stock;
                result.Price = input.Price;
                await context.SaveChangesAsync();
            }

            return new AddProductPayload(result);
        }


        public async Task<AddProductPayload> DeleteProductAsync(int id,
       [Service] ProductQLContext context)
        {
            var result = context.Products.Where(c => c.Id == id).FirstOrDefault();
            if (result != null)
            {
                context.Products.Remove(result);
                await context.SaveChangesAsync();
            }

            return new AddProductPayload(result);
        }


    }
}
