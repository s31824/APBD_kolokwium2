using Kolokwium2_APBD.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2_APBD.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<PurchasedTicket> PurchasedTickets { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concert>().HasData(
            new Concert
            {
                ConcertId = 1,
                Name = "Summer Rock Festival",
                Date = new DateTime(2025, 7, 15),
                AvailableTickets = 150
            }
        );
        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                CustomerId = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                PhoneNumber = "555-123-456"
            }
        );
        modelBuilder.Entity<Ticket>().HasData(
            new Ticket
            {
                TicketId = 1,
                SerialNumber = "SN123456",
                SeatNumber = 12,
            }
        );
        modelBuilder.Entity<Ticket_Concert>().HasData(
            new Ticket_Concert
            {
                TicketConcertId = 1,
                TicketId = 1,
                ConcertId = 1,
                Price = 99
            }
        );
    }
    
}