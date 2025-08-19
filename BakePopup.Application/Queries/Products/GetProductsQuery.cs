using BakePopup.Domain.Products.Entities;

namespace BakePopup.Application.Queries
{
    public record GetProductsQuery : QueryBase<IEnumerable<Product>>
    {
    }
}