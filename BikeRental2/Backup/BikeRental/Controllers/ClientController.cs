namespace BikeRental.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using BikeRental.Models;
    using BikeRental.Models.Repositories;
   
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public ClientController()
            : this(new ClientRepository())
        {
        }

        public ClientController(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        // GET: /Client/
        public ViewResult Index()
        {
            return this.View(this._clientRepository.AllIncluding(client => client.Orders));
        }

        // GET: /Client/Create
        public ActionResult Create()
        {
            return this.View();
        } 

        // POST: /Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid) {
                this._clientRepository.InsertOrUpdate(client);
                this._clientRepository.Save();
                return this.RedirectToAction("Index");
            } 
            
            return this.View();
        }
        
        // GET: /Client/Edit/{id}
        public ActionResult Edit(int id)
        {
            return this.View(this._clientRepository.Find(id));
        }

        // POST: /Client/Edit/{id}
        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid) {
                this._clientRepository.InsertOrUpdate(client);
                this._clientRepository.Save();
                return this.RedirectToAction("Index");
            } 

            return this.View();
        }

        // GET: /Client/Delete/{id}
        public ActionResult Delete(int id)
        {
            return this.View(this._clientRepository.Find(id));
        }

        // POST: /Client/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this._clientRepository.Delete(id);
            this._clientRepository.Save();

            return this.RedirectToAction("Index");
        }
    }
}
