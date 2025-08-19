namespace BakePopup.Application.Queries.Products
{
    public interface IGetProductsDataQuery
    {
        IQueryable<ProductDataQueryResult> Execute();
    }
}