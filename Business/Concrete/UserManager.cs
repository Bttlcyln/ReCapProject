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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);

            
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(int userId)
        {
            return new SuccesDataResult<List<User>>(Messages.UserDeleted);
        }

        public List<User> GetAll()
        {
           return _userDal.GetAll();
        }

        public User GetById(int userId)
        {
           return _userDal.Get(c=>c.UserId == userId);
        }

        public IResult Update(User user)
        {
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
