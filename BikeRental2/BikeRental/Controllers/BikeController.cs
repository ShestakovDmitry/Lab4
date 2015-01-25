namespace BikeRental.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using BikeRental.Models;
    using BikeRental.Models.Repositories;
   
    public class BikeController : Controller
    {
        private readonly IBikeRepository _bikeRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public BikeController()
            : this(new BikeRepository())
        {
        }

        public BikeController(IBikeRepository bikeRepository)
        {
            this._bikeRepository = bikeRepository;
        }

        // GET: /Bike/
        public ViewResult Index()
        {
            return this.View(this._bikeRepository.AllIncluding(bike => bike.Orders));
        }

        // GET: /Bike/Create
        public ActionResult Create()
        {
            return this.View();
        } 

        // POST: /Bike/Create
        [HttpPost]
        public ActionResult Create(Bike bike)
        {
            if (ModelState.IsValid) {
                this._bikeRepository.InsertOrUpdate(bike);
                this._bikeRepository.Save();
                return this.RedirectToAction("Index");
            } 
            
            return this.View();
        }
        
        // GET: /Bike/Edit/{id}
        public ActionResult Edit(int id)
        {
            return this.View(this._bikeRepository.Find(id));
        }

        // POST: /Bike/Edit/{id}
        [HttpPost]
        public ActionResult Edit(Bike bike)
        {
            if (ModelState.IsValid) {
                this._bikeRepository.InsertOrUpdate(bike);
                this._bikeRepository.Save();
                return this.RedirectToAction("Index");
            } 

            return this.View();
        }

        // GET: /Bike/Delete/{id}
        public ActionResult Delete(int id)
        {
            return this.View(this._bikeRepository.Find(id));
        }

        // POST: /Bike/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this._bikeRepository.Delete(id);
            this._bikeRepository.Save();

            return this.RedirectToAction("Index");
        }
    }
}
