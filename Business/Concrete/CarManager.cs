using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCar;
using DataAccess.Concrete.InMemory;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //business codes
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(int carId)
        {
            return new SuccesDataResult<List<Car>>(Messages.CarDeleted);
        }

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

        public IDataResult<Car> GetById(int CarId)
        {
            return new SuccesDataResult<Car>(_carDal.Get(p => p.CarId == CarId));

        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Brand> GetCarsByBrandId(int brandId)
        {
            return new SuccesDataResult<Brand>(_brandDal.Get(p => p.BrandId == brandId));
        }

        public IDataResult<Color> GetCarsByColorId(int colorId)
        {
            return new SuccesDataResult<Color>(_colorDal.Get(p => p.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
