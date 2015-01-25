namespace BikeRental.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using BikeRental.Models;
    using BikeRental.Models.Repositories;
   
    public class OfficeController : Controller
    {
        private readonly IOfficeRepository _officeRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public OfficeController()
            : this(new OfficeRepository())
        {
        }

        public OfficeController(IOfficeRepository officeRepository)
        {
            this._officeRepository = officeRepository;
        }

        // GET: /Office/
        public ViewResult Index()
        {
            return this.View(this._officeRepository.AllIncluding(office => office.Orders));
        }

        // GET: /Office/Create
        public ActionResult Create()
        {
            return this.View();
        } 

        // POST: /Office/Create
        [HttpPost]
        public ActionResult Create(Office office)
        {
            if (ModelState.IsValid) {
                this._officeRepository.InsertOrUpdate(office);
                this._officeRepository.Save();
                return this.RedirectToAction("Index");
            } 
            
            return this.View();
        }
        
        // GET: /Office/Edit/{id}
        public ActionResult Edit(int id)
        {
            return this.View(this._officeRepository.Find(id));
        }

        // POST: /Office/Edit/{id}
        [HttpPost]
        public ActionResult Edit(Office office)
        {
            if (ModelState.IsValid) {
                this._officeRepository.InsertOrUpdate(office);
                this._officeRepository.Save();
                return this.RedirectToAction("Index");
            } 

            return this.View();
        }

        // GET: /Office/Delete/{id}
        public ActionResult Delete(int id)
        {
            return this.View(this._officeRepository.Find(id));
        }

        // POST: /Office/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this._officeRepository.Delete(id);
            this._officeRepository.Save();

            return this.RedirectToAction("Index");
        }
    }
}
