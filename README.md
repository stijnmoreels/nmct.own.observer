# nmct.own.observer
An implementation of the "Observer Design Pattern" and a MVC Controller. 
[MSDN explanation](https://msdn.microsoft.com/en-us/library/ee850490(v=vs.110).aspx)

## Usage
The whole project used the same model: "Sale". In this model you find a propertie "Product". 
In this setup the propertie "Product" of the model "Sale" in the Database will be updated when something change in the "Sale" object.

The same setup can be performed for the "Employee" and "Customer" properties.

So:

Subject: SaleSubject
Observers: ProductObserver, (in the future: EmployeeOberver and CutomerObserver)
