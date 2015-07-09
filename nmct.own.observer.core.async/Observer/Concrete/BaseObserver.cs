using nmct.own.observer.core.async.State;
using nmct.own.observer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.own.observer.core.async.Observer.Concrete
{
    // -------------------------------------------------------------------------------------------------------------------------
    // Stijn Moreels - 08/07/2015
    // 
    // By creating this class there's a much cleaner overview for the Observers 
    // by telling the "Observer" class which types we use (T = Sale, S = SaleState)
    // -------------------------------------------------------------------------------------------------------------------------
    public abstract class BaseObserver : Observer<Sale, SaleState>
    {
        public abstract override void Update(object sender, Tuple<Sale, SaleState> item);
    }
}
