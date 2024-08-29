using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCar;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);

            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(int brandId)
        {
            Brand brand = _brandDal.Get(b => b.BrandId ==brandId);
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccesDataResult<List<Brand>> (_brandDal.GetAll(), Messages.BrandListed);
        }

        

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var result = new SuccesDataResult<Brand>(_brandDal.Get(b => b.BrandId == id), Messages.BrandIdListed);
            if (result.Data != null)
            {
                return result;
            }
            else
            {
                return new ErrorDataResult<Brand>(Messages.BrandIsNull);
            }
        }
    }
}
