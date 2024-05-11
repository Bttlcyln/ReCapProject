using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        IBrandDal _brandDal;

        public CarManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        IColorDal _colorDal;

        public CarManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length<2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
           return new SuccesDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Brand> GetCarsByBrandId(int brandId)
        {
            return new SuccesDataResult<Brand>(_brandDal.Get(p => p.BrandId==brandId));
        }

        public IDataResult<Color> GetCarsByColorId(int colorId)
        {
            return new SuccesDataResult<Color>(_colorDal.Get(p => p.ColorId ==colorId));
        }
    }
}
