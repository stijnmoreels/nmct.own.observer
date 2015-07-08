using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.own.observer.core.Subject.Controller
{
    // -------------------------------------------------------------------------------------------------------------------------
    // Stijn Moreels - 08/07/2015
    // 
    // Interface for al the SubjectControllers. In this setup the SubjectController is the "Client" in the "Observer Pattern".
    // From the derived class you can setup the Observers and Initialize them (see for ex. SaleSubjectController)
    // -------------------------------------------------------------------------------------------------------------------------
    public interface ISubjectController<SUBJECT, TYPE, STATE, OBSERVER>
        where STATE : struct,  IComparable, IFormattable, IConvertible
        where SUBJECT : Subject<TYPE, STATE>, new()
        where TYPE : class
        where OBSERVER : Observer.Observer<TYPE, STATE>
        
    {
        SUBJECT Subject { get; set; }
        IList<OBSERVER> Observers { get; set; }

        void CreateObservers();
        void InitializeObservers();
    }
}
