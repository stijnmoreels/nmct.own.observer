using nmct.own.observer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nmct.own.observer.core.async.Observer.Concrete;
using nmct.own.observer.core.async.State;
using System.Data.Entity;

namespace nmct.own.observer.core.async.Observer
{
    // -------------------------------------------------------------------------------------------------------------------------
    // Stijn Moreels - 08/07/2015
    // 
    // Concrete Observer class (Product)
    // -------------------------------------------------------------------------------------------------------------------------
    public class ProductObserver : BaseObserver
    {
        public override void Update(object sender, Tuple<Sale, SaleState> item)
        {
            using (SalesDBEntities context = new SalesDBEntities())
            {
                Product product = context.Products
                    .Where(p => p.ProductID == item.Item1.ProductID)
                    .SingleOrDefault<Product>();

                switch (item.Item2)
                {
                    case SaleState.SALE_ADD:
                        product.TotalSalesAmount += item.Item1.Quantity;
                        break;
                    case SaleState.SALE_UPDATE:
                        product.TotalSalesAmount = item.Item1.Quantity;
                        break;
                    case SaleState.SALE_DELETE:
                        product.TotalSalesAmount -= item.Item1.Quantity;
                        break;
                    default:
                        break;
                }   
                context.SaveChanges();
            }
        }
    }
}
