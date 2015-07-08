using nmct.own.observer.model;
using nmct.own.observer.core.State;
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
    // By creating this class there's a much cleaner overview for the Subject 
    // by telling the "Subject" class which types we use (T = Sale, S = SaleState)
    // -------------------------------------------------------------------------------------------------------------------------
    public class BaseSubject : Subject<Sale, SaleState>
    {

    }
}
