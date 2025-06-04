using Kolokwium2_APBD.Data;
using Kolokwium2_APBD.DTOs;
using Kolokwium2_APBD.Models;
using Kolokwium2_APBD.Services;
using Microsoft.EntityFrameworkCore;



public class DbService(DatabaseContext context) : IDbService
{
    public async Task<CustomerGetDto> GetCustomerPurchases(int customerId)
    {
        var customer = await context.Customers
            .Include(c => c.PurchasedTickets)
            .ThenInclude(p => p.TicketConcert)
            .ThenInclude(tc => tc.Concert)
            .Include(c => c.PurchasedTickets)
            .ThenInclude(p => p.TicketConcert)
            .ThenInclude(tc => tc.Ticket)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        if (customer == null) throw new ArgumentException("Customer not found");

        return new CustomerGetDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Purchases = customer.PurchasedTickets.Select(p => new CustomerGetDto.PurchaseDto
            {
                Date = p.PurchaseDate,
                Price = p.TicketConcert.Price,
                Ticket = new CustomerGetDto.TicketDto
                {
                    Serial = p.TicketConcert.Ticket.SerialNumber,
                    SeatNumber = p.TicketConcert.Ticket.SeatNumber
                },
                Concert = new CustomerGetDto.ConcertDto
                {
                    Name = p.TicketConcert.Concert.Name,
                    Date = p.TicketConcert.Concert.Date
                }
            }).ToList()
        };
    }

    public Task AddCustomerWithPurchases(CustomerPostDto request)
    {
        throw new NotImplementedException();
    }
}