using Nemocnice.application.Abstraction;
using Nemocnice.application.Abstractions;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Database;

public class KartaService : IKartaService
{
    private readonly NemocniceDbContext _context;

    public KartaService(NemocniceDbContext context)
    {
        _context = context;
    }

    public async Task CreateKarta(Karta karta)
    {
        _context.Karta.Add(karta);
        await _context.SaveChangesAsync();
    }
}