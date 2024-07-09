using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile fromFile, CarImage carImage)
        {
            IResult result = BusinessRule.Run(CheckLimiteOfCarImage(carImage.CarId - 1));
            if (result != null)
            {
                return result;
            }

            var imageResult = FileHelper.Upload(fromFile);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            FileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> Get(int Id)
        {
            return new SuccesDataResult<CarImage>(_carImageDal.Get(c => c.Id == Id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetByCarId(int CarId)
        {
            return new SuccesDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == CarId), Messages.CarImagesListed);


        }

        public IResult Update(IFormFile fromFile, CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            var updateFile = FileHelper.Update(fromFile, image.ImagePath);
            if (!updateFile.Success)
            {
                return new ErrorResult(updateFile.Message);
            }
            carImage.ImagePath = updateFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        //business rules
        private IResult CheckLimiteOfCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
