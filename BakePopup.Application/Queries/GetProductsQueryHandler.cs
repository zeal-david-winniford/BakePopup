using BakePopup.Application.Queries.Products;
using BakePopup.Domain.Products.Entities;
using MediatR;

namespace BakePopup.Application.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IGetProductsDataQuery _query;

        public GetProductsQueryHandler(IGetProductsDataQuery query)
        {
            _query = query;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_query.Execute().Select(p => new Product(p.Id, p.Name, p.Description, p.Price, (int)p.Quantity, p.CreatedAt)).ToList());
            return result;
        }
    }

}