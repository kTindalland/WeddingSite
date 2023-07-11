﻿using WeddingSite.Domain.Entities;

namespace WeddingSite.Application.Infrastructure;
public interface IGuestRepository
{
    Task<Guest?> GetGuestAsync(string id, CancellationToken cancellationToken);
    Task<List<Guest>> GetAllAsync();
}
