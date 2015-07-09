using nmct.own.observer.core.async.State;
using nmct.own.observer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.own.observer.core.async.Observer.Concrete
{
    public class EmployeeObserver : BaseObserver
    {
        public override void Update(object sender, Tuple<Sale, SaleState> item)
        {
            
        }
    }
}
