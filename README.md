# nmct.own.observer
An implementation of the "Observer Design Pattern" and a MVC Controller. 
[MSDN explanation](https://msdn.microsoft.com/en-us/library/ee850490(v=vs.110).aspx)

## Usage
The whole project uses the same model: "Sale". In this model you find a property "Product". 
In this setup the property "Product" of the model "Sale" in the Database will be updated when something change in the "Sale" object.

The same setup can be performed for the "Employee" and "Customer" properties.

So:

## BaseSubject : Subject (abstract)
Abstract class for the Subject. Any class can inherit from this class and make a subject.
(T = Type, S = State)
The Notify-Method will run the "Update"-Method from all the initialized observers.

```
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
```

## BaseObserver : Observer (abstract)
### (in the future: EmployeeOberver and CutomerObserver)
Abstract class for the Observers, has an "Update"-Method that has to be overridden.
```
public abstract class Observer<T, S>
        where T : class
        where S : struct,  IComparable, IFormattable, IConvertible
    {
        public abstract void Update(object sender, Tuple<Sale, SaleState> item);
    }
```

## Asynchronously Notify Observers

Async Subject
```
public abstract class SubjectAsync<T, S>
        where T : class
        where S : struct,  IComparable, IFormattable, IConvertible
    {
        public T Data { get; set; }

        public event EventHandler<Tuple<T, S>> Notify;

        public async Task NotifyObserversAsync(object sender, T data, S state)
        {
            if (data != null)
                await Task.Run(() => { this.Notify(sender, Tuple.Create<T, S>(data, state)); });
        }
    }
```

Async Call Method in Controller

```
[HttpPost]
        public RedirectToRouteResult Edit(Sale sale)
        {
            using (SalesDBEntities context = new SalesDBEntities())
            {
                Sale findSale = context.Sales.Where(s => s.SalesID == sale.SalesID).SingleOrDefault<Sale>();
                findSale.Quantity = sale.Quantity;
                context.SaveChanges();
            }
            // ---------------
            // (***In Here***)
            //---------------
            Task.Run(async () => 
            { 
                await this.SaleSubjectController.Subject.NotifyObserversAsync(this, sale, SaleState.SALE_UPDATE); 
            });
            return RedirectToAction("Index");
        }
```
