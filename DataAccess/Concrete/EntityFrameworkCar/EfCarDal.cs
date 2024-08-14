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
                                 CarId = car.Id,
                                 //BrandId = brand.BrandId,
                                 BrandName = brand.BrandName,                
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
                             on car.Id equals ci.CarId
                             where ci.CarId == carId
                             select new CarsByCarImageDto
                             {
                                 ImagePath = ci.ImagePath,
                                 Id = ci.Id,
                                 CarId = car.Id,
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
                              where car.Id == id
                              select new CarDetailDto
                              {
                                  CarId = car.Id,
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
                             join cl in context.Colors
                             on car.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 //CarName = car.CarName,
                                 //BrandName = brand.BrandName,
                                 //ColorName = cl.ColorName,
                                 //DailyPrice = car.DailyPrice,
                                 //ModelYear = car.ModelYear,
                                 //Description= car.Description,
                                 
                                 CarId = car.Id,
                                 CarName = car.CarName,
                                 //BrandId = car.BrandId,
                                 //ColorId = car.ColorId,
                                 BrandName = brand.BrandName,
                                 ColorName = cl.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description

                             };
                return result.ToList();
            }
        }

        public List<CarsByBrandIdDto> GetCarsByBrandId(int brandId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join cl in context.Colors
                             on car.ColorId equals cl.ColorId
                             where brand.BrandId == brandId
                             select new CarsByBrandIdDto
                             {

                                 CarId = car.Id,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description


                             };
                return result.ToList();
            }
        }

        public List<CarsByColorIdDto> GetCarsByColorId(int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join cl in context.Colors
                             on car.ColorId equals cl.ColorId
                             //
                             where cl.ColorId == colorId
                             //
                             select new CarsByColorIdDto
                             {
                                 CarId = car.Id,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description
                             };
                return result.ToList();

            }
        }

        //public List<CarDetailDto> GetCarByBrandAndColor(int brandId, int colorId)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        var result = from c in context.Cars
        //                     join b in context.Brands
        //                     on c.BrandId equals b.BrandId
        //                     join cl in context.Colors
        //                     on c.ColorId equals cl.ColorId
        //                     where
        //                     (brandId > 0 ? c.BrandId == brandId : true)
        //                     &&
        //                     (colorId > 0 ? c.ColorId == colorId : true)
        //                     select new CarDetailDto()
        //                     {

        //                         BrandName = b.BrandName,
        //                         CarName = c.CarName,
        //                         ColorName = cl.ColorName,
        //                         DailyPrice = c.DailyPrice,
        //                         Description = c.Description,
        //                         ModelYear = c.ModelYear,

        //                     };
        //        return result.ToList();
        //    }
        //}

        //public List<CarsByCarImageDto> GetCarByCarImages(int carId)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        var result = from c in context.Cars
        //                     join ci in context.CarImages
        //                     on c.Id equals ci.CarId
        //                     where ci.CarId == carId
        //                     select new CarsByCarImageDto
        //                     {
        //                         ImagePath = ci.ImagePath,
        //                         Id = ci.Id,
        //                         CarId = c.Id
        //                     };
        //        return result.ToList();
        //    }
        //}

        //public CarDetailDto GetCarDetailById(int id)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        var result = (from c in context.Cars
        //                      join b in context.Brands
        //                      on c.BrandId equals b.BrandId
        //                      join cl in context.Colors
        //                      on c.ColorId equals cl.ColorId
        //                      where c.Id == id
        //                      select new CarDetailDto
        //                      {

        //                          CarName = c.CarName,
        //                          BrandName = b.BrandName,
        //                          ColorName = cl.ColorName,
        //                          DailyPrice = c.DailyPrice,
        //                          ModelYear = c.ModelYear,
        //                          Description = c.Description,


        //                      }).FirstOrDefault();
        //        return result;
        //    }
        //}

        //public List<CarDetailDto> GetCarDetails()
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        var result = from c in context.Cars
        //                     join b in context.Brands
        //                     on c.BrandId equals b.BrandId
        //                     join cl in context.Colors
        //                     on c.ColorId equals cl.ColorId
        //                     select new CarDetailDto
        //                     {

        //                         CarName = c.CarName,
        //                         BrandName = b.BrandName,
        //                         ColorName = cl.ColorName,
        //                         DailyPrice = c.DailyPrice,
        //                         ModelYear = c.ModelYear,
        //                         Description = c.Description,

        //                     };
        //        return result.ToList();
        //    }
        //}

        //public List<CarsByBrandIdDto> GetCarsByBrandId(int brandId)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        var result = from c in context.Cars
        //                     join b in context.Brands
        //                     on c.BrandId equals b.BrandId
        //                     join cl in context.Colors
        //                     on c.ColorId equals cl.ColorId
        //                     where b.BrandId == brandId
        //                     select new CarsByBrandIdDto
        //                     {
        //                         CarName = c.CarName,
        //                         BrandName = b.BrandName,
        //                         ColorName = cl.ColorName,
        //                         DailyPrice = c.DailyPrice,
        //                         ModelYear = c.ModelYear,
        //                         Description = c.Description
        //                     };
        //        return result.ToList();
        //    }
        //}



        //public List<CarsByColorIdDto> GetCarsByColorId(int colorId)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        var result = from c in context.Cars
        //                     join b in context.Brands
        //                     on c.BrandId equals b.BrandId
        //                     join cl in context.Colors
        //                     on c.ColorId equals cl.ColorId
        //                     where cl.ColorId == colorId
        //                     select new CarsByColorIdDto
        //                     {
        //                         CarName = c.CarName,
        //                         BrandName = b.BrandName,
        //                         ColorName = cl.ColorName,
        //                         DailyPrice = c.DailyPrice,
        //                         ModelYear = c.ModelYear,
        //                         Description = c.Description
        //                     };
        //        return result.ToList();
        //    }
        //}

    }
}
