using Convey.CQRS.Queries;

namespace WeddingSite.Application.Queries;

public record GenerateDatabaseId() : IQuery<string>;