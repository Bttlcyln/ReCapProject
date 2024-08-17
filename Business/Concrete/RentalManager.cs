using Azure.Core;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCar;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarDal _carDal;

        public RentalManager(IRentalDal rentalDal, ICarDal cardal)
        {
            _rentalDal = rentalDal;
            _carDal = cardal;
        }

        public IResult Add(Rental rental)
        {
            Random random = new Random();
            int findexScore=random.Next(0, 1901);
            Car car = _carDal.Get(c => c.Id == rental.CarId);
            if (car == null)
            {
                return new ErrorResult(Messages.CarNotFound);
            }       

            if (findexScore < car.FindexScore)
            {
                return new ErrorResult(Messages.FindexScoreInNotEnough);
            }

            var rentals = _rentalDal.GetAll(r => r.CarId == rental.CarId).OrderByDescending(r => r.RentDate).FirstOrDefault(); ;

            if (rentals != null)
            {

                if (rentals.ReturnDate > rental.RentDate)
                {
                    return new ErrorResult(Messages.CarWasRentedByElse);
                }

                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);

            }
            try
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            catch
            {

                return new ErrorResult(Messages.RentalNotFound);
            }
        }

        public IResult Delete(Rental rental)
        {
            return new SuccesDataResult<List<Rental>>(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetRentalsByCarId(int carId)
        {
            var rentals = _rentalDal.GetAll(r => r.CarId == carId);
            var rentalWithMaxRendDate = rentals.OrderByDescending(r => r.RentDate).FirstOrDefault();
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccesDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            return new SuccessResult(Messages.RentalAdded);
        }
    }
}
