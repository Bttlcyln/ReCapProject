using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCar
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, ReCapContext>, IBrandDal
    {
        public List<CarDetailDto> GetByBrands(int brandId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var query = (from car in context.Cars
                            join brand in context.Brands on car.BrandId equals brand.BrandId
                            join color in context.Colors on car.ColorId equals color.ColorId
                            where car.BrandId == brandId
                            select new CarDetailDto
                            {
                                CarId = car.CarId,
                                BrandId = brand.BrandId,
                                ColorId = color.ColorId,
                                BrandName = brand.BrandName,
                                ColorName = color.ColorName,
                                CarName = car.CarName,
                                DailyPrice = car.DailyPrice,
                                Description = car.Description,
                                ModelYear = car.ModelYear
                            }).ToList();

                return query;
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.BrandId
                             select new CarDetailDto
                             {
                                 CarId = p.CarId,
                                 CarName = p.CarName,
                                 BrandId = p.BrandId,
                                 ColorId = p.ColorId,
                                 ModelYear = p.ModelYear,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description
                             };
                return result.ToList();
            }
        }

    }
}
