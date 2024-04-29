using Business.Concrete;
using DataAccess.Concrete.InMemory;

CarManager carManager=new CarManager(new InMemoryCarDal());

foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.CarId);
}
Console.WriteLine();