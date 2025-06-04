using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2_APBD.Models;

public class Ticket_Concert
{
    [Key] public int TicketConcertId { get; set; }

    [Column("TicketId")] public int TicketId { get; set; }

    [Column("ConcertId")] public int ConcertId { get; set; }

    public int Price { get; set; }
    
    [ForeignKey("TicketId")] public virtual Ticket Ticket { get; set; } = null!;

    [ForeignKey("ConcertId")] public virtual Concert Concert { get; set; } = null!;
}