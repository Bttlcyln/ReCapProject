using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCar
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, ReCapContext>, ICarImageDal
    {
        public List<CarsByCarImageDto> GetCarsByCarImage(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             where ci.CarId == carId
                             select new CarsByCarImageDto
                             {
                                 ImagePath = ci.ImagePath,
                                 Id = ci.Id,
                                 CarId = c.Id,
                             };
                return result.ToList();

            }
        }
    }
}
