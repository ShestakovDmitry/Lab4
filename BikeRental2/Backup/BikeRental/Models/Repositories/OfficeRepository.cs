namespace BikeRental.Models.Repositories
{ 
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using BikeRental.Models;
    using BikeRental.Models.DbContext;
    
    public interface IOfficeRepository
    {
        IQueryable<Office> All { get; }
        IQueryable<Office> AllIncluding(params Expression<Func<Office, object>>[] includeProperties);
        Office Find(int id);
        void InsertOrUpdate(Office office);
        void Delete(int id);
        void Save();
    }

    public class OfficeRepository : IOfficeRepository
    {
        private readonly BikeRentalContext _context = new BikeRentalContext();

        public IQueryable<Office> All
        {
            get { return this._context.Office; }
        }

        public IQueryable<Office> AllIncluding(params Expression<Func<Office, object>>[] includeProperties)
        {
            IQueryable<Office> query = this._context.Office;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public Office Find(int id)
        {
            return this._context.Office.Find(id);
        }

        public void InsertOrUpdate(Office office)
        {
            if (office.Id == default(int)) {
                // New entity
                this._context.Office.Add(office);
            } else {
                // Existing entity
                this._context.Entry(office).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var office = this._context.Office.Find(id);
            this._context.Office.Remove(office);
        }

        public void Save()
        {
            this._context.SaveChanges();
        }
    }
}