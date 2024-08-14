using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarsByBrandIdDto> GetCarsByBrandId(int brandId);
        List<CarsByColorIdDto> GetCarsByColorId(int colorId);       
        List<CarsByCarImageDto> GetCarByCarImages(int carId);
        CarDetailDto GetCarDetailById(int id);
        List<CarDetailDto> GetCarByBrandAndColor(int brandId, int colorId);


    }
}
