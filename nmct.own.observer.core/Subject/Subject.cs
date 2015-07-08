using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.own.observer.core.Subject
{
    // -------------------------------------------------------------------------------------------------------------------------
    // Stijn Moreels - 08/07/2015
    // 
    // Abstract class for the Subject. Any class can inherit from this class and make a subject.
    // 
    // T = Type
    // S = State
    // 
    // The Notify-Method will run the "Update"-Method from all the initialized observers
    // -------------------------------------------------------------------------------------------------------------------------
    public abstract class Subject<T, S>
        where T : class
        where S : struct,  IComparable, IFormattable, IConvertible
    {
        public T Data { get; set; }

        public event EventHandler<Tuple<T, S>> Notify;

        public void NotifyObservers(object sender, T data, S state)
        {
            if (data != null)
                this.Notify(sender, Tuple.Create<T, S>(data, state));
        }
    }
}
