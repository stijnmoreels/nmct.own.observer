using nmct.own.observer.model;
using nmct.own.observer.web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedListExtensions;
using nmct.own.pagination.core;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using nmct.own.observer.core.Subject.Controller;
using nmct.own.observer.core.Subject;
using nmct.own.observer.core.State;
using nmct.own.observer.core.Observer.Concrete;

namespace nmct.own.observer.web.Controllers
{
    // -------------------------------------------------------------------------------------------------------------------------
    // Stijn Moreels - 08/07/2015
    // 
    // Concrete Controller
    // -> Has and ISubjectController propertie so this controller can talk to the Subject (***In Here****)
    // -------------------------------------------------------------------------------------------------------------------------
    public class SaleController : Controller
    {
        [Dependency]
        public ISubjectController<BaseSubject, Sale, SaleState, BaseObserver> SaleSubjectController { get; set; }

        [HttpGet]
        public ViewResult Index()
        {
            List<Sale> sales = new List<Sale>();
            using (SalesDBEntities context = new SalesDBEntities())
            {
                sales = context.Sales
                    .Include(s => s.Employee)
                    .Include(s => s.Customer)
                    .Include(s => s.Product)
                    .Take(100).ToList<Sale>();
                SalesViewModel viewModel = new SalesViewModel();
                viewModel.Sales = sales;
                return View(viewModel);
            }
        }

        [HttpGet]
        public ViewResult Edit(Sale sale)
        {
            // TODO: Edit the Sale-Object in the Database

            // ---------------
            // (***In Here***)
            //---------------
            this.SaleSubjectController.Subject.NotifyObservers(this, sale, SaleState.SALE_UPDATE);
            return View("Index");
        }
    }
}