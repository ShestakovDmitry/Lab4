namespace BikeRental.Models.Repositories
{ 
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using BikeRental.Models;
    using BikeRental.Models.DbContext;
    
    public interface IBikeRepository
    {
        IQueryable<Bike> All { get; }
        IQueryable<Bike> AllIncluding(params Expression<Func<Bike, object>>[] includeProperties);
        Bike Find(int id);
        void InsertOrUpdate(Bike bike);
        void Delete(int id);
        void Save();
    }

    public class BikeRepository : IBikeRepository
    {
        private readonly BikeRentalContext _context = new BikeRentalContext();

        public IQueryable<Bike> All
        {
            get { return this._context.Bike; }
        }

        public IQueryable<Bike> AllIncluding(params Expression<Func<Bike, object>>[] includeProperties)
        {
            IQueryable<Bike> query = this._context.Bike;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public Bike Find(int id)
        {
            return this._context.Bike.Find(id);
        }

        public void InsertOrUpdate(Bike bike)
        {
            if (bike.Id == default(int)) {
                // New entity
                this._context.Bike.Add(bike);
            } else {
                // Existing entity
                this._context.Entry(bike).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var bike = this._context.Bike.Find(id);
            this._context.Bike.Remove(bike);
        }

        public void Save()
        {
            this._context.SaveChanges();
        }
    }
}