using Microsoft.EntityFrameworkCore;

namespace Kolokwium2_APBD.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext() { }
    
    public DatabaseContext(DbContextOptions options) : base(options) { }
}