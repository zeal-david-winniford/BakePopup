using BakePopup.Application.Queries.Products;
using Microsoft.EntityFrameworkCore;

namespace BakePopup.Data.Queries.Products
{
    public class GetProductsDataQuery : IGetProductsDataQuery
    {
        private readonly BakePopupContext _dbContext;

        public GetProductsDataQuery(BakePopupContext context)
        {
            _dbContext = context;
        }

        public IQueryable<ProductDataQueryResult> Execute()
        {
            return _dbContext.Products.AsNoTracking().Select(p => new ProductDataQueryResult
            {
                Id = p.DomainId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                CreatedAt = p.CreatedAt
            });
        }
    }
}