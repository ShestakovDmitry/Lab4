namespace BikeRental.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using BikeRental.Models;
    using BikeRental.Models.Repositories;
   
    public class OrderController : Controller
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IOrderRepository _orderRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public OrderController()
            : this(new BikeRepository(), new OfficeRepository(), new ClientRepository(), new OrderRepository())
        {
        }

        public OrderController(IBikeRepository bikeRepository, IOfficeRepository officeRepository, IClientRepository clientRepository, IOrderRepository orderRepository)
        {
            this._bikeRepository = bikeRepository;
            this._officeRepository = officeRepository;
            this._clientRepository = clientRepository;
            this._orderRepository = orderRepository;
        }

        // GET: /Order/
        public ViewResult Index()
        {
           return this.View(this._orderRepository.AllIncluding(order => order.Bike, order => order.Office, order => order.Client));
        }

        public ViewResult Main()
        {
            this.ViewBag.PossibleBike = this._bikeRepository.All;
            this.ViewBag.Orders = this._orderRepository.AllIncluding(order => order.Bike, order => order.Office, order => order.Client);
            return this.View();
        }

        [HttpPost]
        public PartialViewResult FilterByBike()
        {
            int ID;
            int.TryParse(Request.Form["BikeFilter"], out ID);
            if (ID != -1)
            {
                this.ViewBag.Orders = this._orderRepository.AllIncluding(order => order.Bike, order => order.Office, order => order.Client).Where(order => (order.Bike.Id == ID));
                this.ViewBag.PossibleBike = this._bikeRepository.All;
                return this.PartialView();
            }
            else
            {
                this.ViewBag.PossibleBike = this._bikeRepository.All;
                this.ViewBag.Orders = this._orderRepository.AllIncluding(order => order.Bike, order => order.Office, order => order.Client);
                return this.PartialView();
            }
        }

        // GET: /Order/Create
        public ActionResult Create()
        {
            this.ViewBag.PossibleBike = this._bikeRepository.All;
            this.ViewBag.PossibleOffice = this._officeRepository.All;
            this.ViewBag.PossibleClient = this._clientRepository.All;
            return this.View();
        } 

        // POST: /Order/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid) {
                this._orderRepository.InsertOrUpdate(order);
                this._orderRepository.Save();
                return this.RedirectToAction("Index");
            } 
            
            this.ViewBag.PossibleBike = this._bikeRepository.All;
            this.ViewBag.PossibleOffice = this._officeRepository.All;
            this.ViewBag.PossibleClient = this._clientRepository.All;
            return this.View();
        }
        
        // GET: /Order/Edit/{id}
        public ActionResult Edit(int id)
        {
            this.ViewBag.PossibleBike = this._bikeRepository.All;
            this.ViewBag.PossibleOffice = this._officeRepository.All;
            this.ViewBag.PossibleClient = this._clientRepository.All;
            return this.View(this._orderRepository.Find(id));
        }

        // POST: /Order/Edit/{id}
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid) {
                this._orderRepository.InsertOrUpdate(order);
                this._orderRepository.Save();
                return this.RedirectToAction("Index");
            } 

            this.ViewBag.PossibleBike = this._bikeRepository.All;
            this.ViewBag.PossibleOffice = this._officeRepository.All;
            this.ViewBag.PossibleClient = this._clientRepository.All;
            return this.View();
        }

        // GET: /Order/Delete/{id}
        public ActionResult Delete(int id)
        {
            return this.View(this._orderRepository.Find(id));
        }

        // POST: /Order/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this._orderRepository.Delete(id);
            this._orderRepository.Save();

            return this.RedirectToAction("Index");
        }


        

    }
}
