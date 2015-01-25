namespace BikeRental.Models.Repositories
{ 
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using BikeRental.Models;
    using BikeRental.Models.DbContext;
    
    public interface IClientRepository
    {
        IQueryable<Client> All { get; }
        IQueryable<Client> AllIncluding(params Expression<Func<Client, object>>[] includeProperties);
        Client Find(int id);
        void InsertOrUpdate(Client client);
        void Delete(int id);
        void Save();
    }

    public class ClientRepository : IClientRepository
    {
        private readonly BikeRentalContext _context = new BikeRentalContext();

        public IQueryable<Client> All
        {
            get { return this._context.Client; }
        }

        public IQueryable<Client> AllIncluding(params Expression<Func<Client, object>>[] includeProperties)
        {
            IQueryable<Client> query = this._context.Client;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public Client Find(int id)
        {
            return this._context.Client.Find(id);
        }

        public void InsertOrUpdate(Client client)
        {
            if (client.Id == default(int)) {
                // New entity
                this._context.Client.Add(client);
            } else {
                // Existing entity
                this._context.Entry(client).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var client = this._context.Client.Find(id);
            this._context.Client.Remove(client);
        }

        public void Save()
        {
            this._context.SaveChanges();
        }
    }
}