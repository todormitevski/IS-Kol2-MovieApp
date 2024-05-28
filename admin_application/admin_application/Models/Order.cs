using admin_application.Models;
using System.ComponentModel.DataAnnotations;

namespace admin_application.Models
{
    public class Order : BaseEntity
    {
        public string? OwnerId { get; set; }
        public EShopApplicationUser? Owner { get; set; }
        public ICollection<TicketInOrder>? ProductInOrders { get; set; }
    }
}
