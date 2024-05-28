using System.ComponentModel.DataAnnotations;

namespace admin_application.Models
{
    public class Ticket : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double Rating { get; set; }
        public virtual EShopApplicationUser? CreatedBy { get; set; }
        public ICollection<TicketInOrder>? ProductInOrders { get; set; }
    }
}
