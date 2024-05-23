using Business.Concrete;
using DataAccess.Concrete.EntityFrameworkCar;
using DataAccess.Concrete.InMemory;

//CarTest();
//ColorTest();
//BrandTest();
//UserTest();
//CustomerTest();
//RentalTest();

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal(), new EfRentalDal(), new EfBrandDal(), new EfColorDal());

    var list = carManager.GetAll();

    var result = carManager.GetCarDetails();

    if (result.Success == true)
    {
        foreach (var car in list.Data)
        {
            Console.WriteLine(car.CarName + "/" + car.CarId);
        }

    }
    else
    {
        Console.WriteLine(result.Message);
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

static void UserTest()
{
    UserManager userManager = new UserManager(new EfUserDal());
    foreach (var user in userManager.GetAll())
    {
        Console.WriteLine(user.UserFirstName + user.UserLastName);
    }
}

static void CustomerTest()
{
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
    foreach (var customer in customerManager.GetAll())
    {
        Console.WriteLine(customer.CompanyName);
    }
}



static void RentalTest()
{
    RentalManager rentalM = new RentalManager(new EfRentalDal());
    foreach (var rental in (rentalM.GetAll()).Data)
    {
        Console.WriteLine(rental.CarId);
    }
}