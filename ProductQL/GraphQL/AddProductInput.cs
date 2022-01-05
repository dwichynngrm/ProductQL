namespace ProductQL.GraphQL
{
    public record AddProductInput
    (
       int? Id,
       string Name,
       int Stock,
       double Price
     );
    
}
