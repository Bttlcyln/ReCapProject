using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCar;

using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IRentalDal _rentalDal;
        IBrandDal _brandDal;
        IColorDal _colorDal;

        public CarManager(ICarDal carDal, IRentalDal rentalDal, IBrandDal brandDal, IColorDal colorDal)
        {
            _carDal = carDal;
            _rentalDal = rentalDal;
            _brandDal = brandDal;
            _colorDal = colorDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //business codes
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
           Add(car);
            if (car.DailyPrice<250)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }

        public IResult Delete(int Id)
        {
            return new SuccesDataResult<List<Car>>(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour == 17)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}


            List<Car> list = _carDal.GetAll();

            var today = DateTime.Now;

            List<Rental> rentalCarIdList = _rentalDal.GetAll(c => c.RentDate < today && c.ReturnDate > today);

            var onlySelectedCarId = rentalCarIdList.Select(c => c.CarId);

            list.RemoveAll(c => onlySelectedCarId.Contains(c.CarId));

            return new SuccesDataResult<List<Car>>(list, Messages.CarListed);
        }

     

      
       

        public IDataResult<List<CarDetailDto>> GetCarByBrandAndColor(int brandId, int colorId)
        {
            var cars = _carDal.GetCarByBrandAndColor(brandId, colorId);

            if (cars == null || cars.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>();
            }

            return new SuccesDataResult<List<CarDetailDto>>(cars);
        }

        public IDataResult<List<CarsByBrandIdDto>> GetCarByBrandIdDto(int brandId)
        {
            return new SuccesDataResult<List<CarsByBrandIdDto>>(_carDal.GetCarsByBrandId(brandId));
        }

        public IDataResult<List<CarsByColorIdDto>> GetCarByColorIdDto(int colorId)
        {
            return new SuccesDataResult<List<CarsByColorIdDto>>(_carDal.GetCarsByColorId(colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccesDataResult<List<CarDetailDto>>(_brandDal.GetByBrands(brandId));
        }

        public IDataResult<List<CarsByCarImageDto>> GetCarsByCarImage(int carId)
        {
            return new SuccesDataResult<List<CarsByCarImageDto>>(_carDal.GetCarByCarImages(carId));
        }

        public IDataResult<Color> GetCarsByColorId(int colorId)
        {
            return new SuccesDataResult<Color>(_colorDal.Get(p => p.ColorId == colorId));
        }

        [ValidationAspect(typeof(Car))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            return new SuccessResult(Messages.CarUpdated);
        }

        IDataResult<CarDetailDto> ICarService.GetById(int id)
        {
            return new SuccesDataResult<CarDetailDto>(_carDal.GetCarDetailById(id));
        }

        IDataResult<List<Car>> ICarService.GetCarsByBrandId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c=> c.BrandId==id));
        }

        IDataResult<List<Car>> ICarService.GetCarsByColorId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }
    }
}
