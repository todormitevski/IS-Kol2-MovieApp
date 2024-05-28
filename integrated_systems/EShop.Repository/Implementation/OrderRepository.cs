using EShop.Domain.Domain;
using EShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Order> orders;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
            orders = _db.Set<Order>();
        }

        public List<Order> GetAllOrders()
        {
            return orders
                .Include(z => z.Owner)
                .Include(z => z.ProductInOrders)
                .Include("ProductInOrders.OrderedProduct")
                .Include("ProductInOrders.OrderedProduct.Movie")
                .ToList();
        }

        public Order GetDetailsForOrder(BaseEntity id)
        {
            return orders
                .Include(z => z.Owner)
                .Include(z => z.ProductInOrders)
                .Include("ProductInOrders.OrderedProduct")
                .Include("ProductInOrders.OrderedProduct.Movie")
                .SingleOrDefaultAsync(z => z.Id == id.Id).Result;
        }
    }
}
