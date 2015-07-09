using nmct.own.observer.core.async.Observer;
using nmct.own.observer.core.async.Observer.Concrete;
using nmct.own.observer.core.async.State;
using nmct.own.observer.core.async.Subject.Controller;
using nmct.own.observer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.own.observer.core.async.Subject.Concrete
{
    // -------------------------------------------------------------------------------------------------------------------------
    // Stijn Moreels - 08/07/2015
    // 
    // Concreate SubjectController ("Client" in "Observer Pattern")
    // -------------------------------------------------------------------------------------------------------------------------
    public class SaleSubjectController : ISubjectController<BaseSubjectAsync, Sale, SaleState, BaseObserver>
    {
        public IList<BaseObserver> Observers { get; set; }
        public BaseSubjectAsync Subject { get; set; }

        public SaleSubjectController()
        {
            CreateObservers();
            InitializeObservers();
        }

        // ------------------------
        // From ISubjectController
        // ------------------------
        public void CreateObservers()
        {
            this.Observers = new List<BaseObserver>();
            this.Observers.Add(new ProductObserver());
        }

        // ------------------------
        // From ISubjectController
        // ------------------------
        public void InitializeObservers()
        {
            this.Subject = new BaseSubjectAsync();
            foreach (BaseObserver observer in this.Observers)
                this.Subject.Notify += observer.Update;
        }
    }
}
