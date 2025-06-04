using System.ComponentModel.DataAnnotations;

namespace Kolokwium2_APBD.Models;

public class Concert
{
   [Key] public int ConcertId { get; set; }
    
   [Required] [MaxLength(100)] public string Name { get; set; } = null!;
    
   public DateTime Date { get; set; }
    
   public int AvailableTickets { get; set; }
    
   public virtual ICollection<Ticket_Concert> TicketConcerts { get; set; } = null!;
}