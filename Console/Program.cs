using Business.Concrete;
using DataAccess.Concrete.EntityFrameworkCar;
using DataAccess.Concrete.InMemory;

CarManager carManager=new CarManager(new EfCarDal());

foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}
