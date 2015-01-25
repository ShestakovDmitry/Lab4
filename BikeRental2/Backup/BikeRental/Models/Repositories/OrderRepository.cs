namespace BikeRental.Models.Repositories
{ 
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using BikeRental.Models;
    using BikeRental.Models.DbContext;
    
    public interface IOrderRepository
    {
        IQueryable<Order> All { get; }
        IQueryable<Order> AllIncluding(params Expression<Func<Order, object>>[] includeProperties);
        Order Find(int id);
        void InsertOrUpdate(Order order);
        void Delete(int id);
        void Save();
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly BikeRentalContext _context = new BikeRentalContext();

        public IQueryable<Order> All
        {
            get { return this._context.Order; }
        }

        public IQueryable<Order> AllIncluding(params Expression<Func<Order, object>>[] includeProperties)
        {
            IQueryable<Order> query = this._context.Order;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public Order Find(int id)
        {
            return this._context.Order.Find(id);
        }

        public void InsertOrUpdate(Order order)
        {
            if (order.Id == default(int)) {
                // New entity
                this._context.Order.Add(order);
            } else {
                // Existing entity
                this._context.Entry(order).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var order = this._context.Order.Find(id);
            this._context.Order.Remove(order);
        }

        public void Save()
        {
            this._context.SaveChanges();
        }
    }
}