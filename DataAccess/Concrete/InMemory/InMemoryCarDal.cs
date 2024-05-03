using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
               new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 1500, ModelYear = 2022, Description = "2022 Beyaz Güvercin" },
               new Car { CarId = 2, BrandId = 2, ColorId = 1, DailyPrice = 1000, ModelYear = 2008, Description = "Taklalı Güvercin" },
               new Car { CarId = 3, BrandId = 3, ColorId = 2, DailyPrice = 5000, ModelYear = 2024, Description = "Zengin işi" },
               new Car { CarId = 4, BrandId = 1, ColorId = 3, DailyPrice = 2000, ModelYear = 2022, Description = "Temiz Klasik" },
               new Car { CarId = 5, BrandId = 2, ColorId = 2, DailyPrice = 3500, ModelYear = 2020, Description = "Araziye Gitmelik" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(p => p.CarId == CarId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
