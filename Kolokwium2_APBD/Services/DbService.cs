using Kolokwium2_APBD.Data;

namespace Kolokwium2_APBD.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    
    
    
}