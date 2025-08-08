using MediatR;

namespace BakePopup.Application.Queries
{
    public class TestQueryHandler : IRequestHandler<TestQuery, string>
    {
        public Task<string> Handle(TestQuery request, CancellationToken cancellationToken)
        {
            // Handle the query and return a response
            return Task.FromResult("Test query response");
        }
    }

}