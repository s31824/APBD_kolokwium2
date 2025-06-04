using System.ComponentModel.DataAnnotations;
using Kolokwium2_APBD.Models;


public class Ticket
{
    [Key] public int TicketId { get; set; }

    [Required] [MaxLength(50)] public string SerialNumber { get; set; } = null!;
    
    [Required] public int SeatNumber { get; set; }

    public virtual ICollection<Ticket_Concert> TicketConcerts { get; set; } = null!;
}