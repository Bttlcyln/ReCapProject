using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarsByBrandIdDto>> GetCarsByBrandId(int id);
        IDataResult<List<CarsByColorIdDto>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarsByBrandIdDto>> GetCarByBrandIdDto(int brandId);
        IDataResult<List<CarsByColorIdDto>> GetCarByColorIdDto(int colorId);
        IDataResult<List<CarsByCarImageDto>> GetCarsByCarImage(int carId);
        IDataResult<List<CarDetailDto>> GetCarByBrandAndColor(int brandId, int colorId);
        IDataResult<CarDetailDto> GetById(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(int CarId);
        IResult AddTransactionalTest(Car car);
    }
}
