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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);

            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(int colorId)
        {
            Color color = _colorDal.Get(b => b.ColorId == colorId);
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccesDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListed);
        }

        public IDataResult<Color> GetById(int id)
        {
           var result = new SuccesDataResult<Color>(_colorDal.Get(b => b.ColorId ==id), Messages.ColorListed);
            if (result.Data != null)
            {
                return result;
            }
            else
            {
                return new ErrorDataResult<Color>(Messages.ColorIsNull);
            }
        }

        public IResult Update(Color color)
        {
           _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
