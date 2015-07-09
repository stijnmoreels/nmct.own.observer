using nmct.own.observer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nmct.own.observer.core.async.State;

namespace nmct.own.observer.core.async.Subject
{
    // -------------------------------------------------------------------------------------------------------------------------
    // Stijn Moreels - 08/07/2015
    // 
    // By creating this class there's a much cleaner overview for the Subject 
    // by telling the "Subject" class which types we use (T = Sale, S = SaleState)
    // -------------------------------------------------------------------------------------------------------------------------
    public class BaseSubjectAsync : SubjectAsync<Sale, SaleState>
    {

    }
}
