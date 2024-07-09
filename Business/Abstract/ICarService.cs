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
        IDataResult<Brand> GetCarsByBrandId(int brandId);
        IDataResult<Color> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Car>GetById(int CarId);
        
        IResult Add(Car car);
        
        IResult Update(Car car);
        IResult Delete(int carId);
        IResult AddTransactionalTest(Car car);
    }
}
