using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCar
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarByBrandAndColor(int brandId, int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             where
                             (brandId > 0 ? car.BrandId == brandId : true)
                             &&
                             (colorId > 0 ? car.ColorId == colorId : true)
                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 BrandId = brand.BrandId,
                                 CarName = car.CarName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,

                             };
                return result.ToList();
            }
        }

        public List<CarsByCarImageDto> GetCarByCarImages(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join ci in context.CarImages
                             on car.CarId equals ci.CarId
                             where ci.CarId == carId
                             select new CarsByCarImageDto
                             {
                                 ImagePath = ci.ImagePath,
                                 Id = ci.Id,
                                 CarId = car.CarId,
                             };
                return result.ToList();

            }
        }

        public CarDetailDto GetCarDetailById(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from car in context.Cars
                              join brand in context.Brands
                              on car.BrandId equals brand.BrandId
                              join cl in context.Colors
                              on car.ColorId equals cl.ColorId
                              where car.CarId == id
                              select new CarDetailDto
                              {
                                  CarId = car.CarId,
                                  CarName = car.CarName,
                                  BrandName = brand.BrandName,
                                  ColorName = cl.ColorName,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = car.ModelYear,
                                  Description = car.Description,
                              }).FirstOrDefault();
                return result;

            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandId = car.BrandId,
                                 ColorId = car.ColorId,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description
                             };
                return result.ToList();
            }
        }

        public List<CarsByBrandIdDto> GetCarsByBrandId(int brandId)
        {
           using (ReCapContext context =new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join cl in context.Colors
                             on car.ColorId equals cl.ColorId
                             where brand.BrandId == brandId
                             select new CarsByBrandIdDto
                             {
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 //ModelYear = car.ModelYear,
                                 Description = car.Description


                             };
                return result.ToList();
            }
        }

        public List<CarsByColorIdDto> GetCarsByColorId(int colorId)
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join cl in context.Colors
                             on car.ColorId equals cl.ColorId
                             where cl.ColorId == colorId
                             select new CarsByColorIdDto
                             {
                                 CarName= car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = car.DailyPrice,
                                // ModelYear = car.ModelYear,
                                 Description = car.Description
                             };
                return result.ToList() ;
                             
            }
        }
    }
}
