using nmct.own.observer.model;
using nmct.own.observer.core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.own.observer.core.Observer
{
    // -------------------------------------------------------------------------------------------------------------------------
    // Stijn Moreels - 08/07/2015
    // 
    // Abstract class for the Observers, has an "Update"-Method that has to be overridden
    // -------------------------------------------------------------------------------------------------------------------------
    public abstract class Observer<T, S>
        where T : class
        where S : struct,  IComparable, IFormattable, IConvertible
    {
        public abstract void Update(object sender, Tuple<Sale, SaleState> item);
    }
}
