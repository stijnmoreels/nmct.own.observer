using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.own.observer.core.async.State
{
    // -------------------------------------------------------------------------------------------------------------------------
    // Stijn Moreels - 08/07/2015
    // 
    // And extra feature of the "Observer Pattern" is the use of states (see for ex. ProductObserver)
    // -------------------------------------------------------------------------------------------------------------------------
    public enum SaleState
    {
        SALE_ADD,
        SALE_UPDATE,
        SALE_DELETE
    }
}
