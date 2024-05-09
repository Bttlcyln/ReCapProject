using Business.Concrete;
using DataAccess.Concrete.EntityFrameworkCar;
using DataAccess.Concrete.InMemory;

CarTest();
//ColorTest();
//BrandTest();

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());

    foreach (var car in carManager.GetCarDetails())
    {
        Console.WriteLine(car.CarName);
    }
}

static void ColorTest()
{
    ColorManager colormanager = new ColorManager(new EfColorDal());
    foreach (var color in colormanager.GetAll())
    {
        Console.WriteLine(color.ColorName);
    }
}

static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    foreach (var brand in brandManager.GetAll())
    {
        Console.WriteLine(brand.BrandName);
    }
}