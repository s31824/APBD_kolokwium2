using Kolokwium2_APBD.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2_APBD.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public object PurchasedTickets { get; set; }

    protected DatabaseContext() { }
    
    public DatabaseContext(DbContextOptions options) : base(options) { }
}