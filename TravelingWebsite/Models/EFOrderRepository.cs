using Microsoft.EntityFrameworkCore;

namespace TravelingWebsite.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private StoreDBContext context;
        public EFOrderRepository(StoreDBContext context)
        {
            this.context = context;
        }
        public IQueryable<Order> Orders => context.Orders
                                            .Include(o => o.Lines)
                                            .ThenInclude(l => l.Package);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Package));
            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
