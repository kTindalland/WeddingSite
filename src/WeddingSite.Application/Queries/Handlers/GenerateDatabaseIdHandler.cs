using Convey.CQRS.Queries;
using WeddingSite.Application.Infrastructure;

namespace WeddingSite.Application.Queries.Handlers;

public class GenerateDatabaseIdHandler : IQueryHandler<GenerateDatabaseId, string>
{
    private readonly IGuestRepository _guestRepository;

    public GenerateDatabaseIdHandler(IGuestRepository guestRepository)
    {
        _guestRepository = guestRepository;
    }
    
    public async Task<string> HandleAsync(GenerateDatabaseId query, CancellationToken cancellationToken = new CancellationToken())
    {
        return await _guestRepository.GenerateDatabaseIdAsync();
    }
}