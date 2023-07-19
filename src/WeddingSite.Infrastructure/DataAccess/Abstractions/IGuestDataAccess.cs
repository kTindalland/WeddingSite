﻿using WeddingSite.Infrastructure.Items;

namespace WeddingSite.Infrastructure.DataAccess.Abstractions;
internal interface IGuestDataAccess
{
    Task<Guest?> GetGuestAsync(string id, CancellationToken cancellationToken);
    Task<List<Guest>> GetAllAsync();
    Task CreateGuest(Guest newGuest, CancellationToken cancellationToken);

    Task<string> GenerateDatabaseIdAsync();
}
