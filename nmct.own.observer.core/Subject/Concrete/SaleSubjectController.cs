using nmct.own.observer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nmct.own.observer.core.Subject;
using nmct.own.observer.core.Observer;
using nmct.own.observer.core.State;
using nmct.own.observer.core.Observer.Concrete;
using nmct.own.observer.core.Subject.Controller;

namespace nmct.own.observer.core.Subject.Concrete
{
    // -------------------------------------------------------------------------------------------------------------------------
    // Stijn Moreels - 08/07/2015
    // 
    // Concreate SubjectController ("Client" in "Observer Pattern")
    // -------------------------------------------------------------------------------------------------------------------------
    public class SaleSubjectController : ISubjectController<BaseSubject, Sale, SaleState, BaseObserver>
    {
        public IList<BaseObserver> Observers { get; set; }
        public BaseSubject Subject { get; set; }

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
            this.Subject = new BaseSubject();
            foreach (BaseObserver observer in this.Observers)
                this.Subject.Notify += observer.Update;
        }
    }
}
