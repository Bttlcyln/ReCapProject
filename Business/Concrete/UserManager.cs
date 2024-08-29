using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCar;
using Entities.Concrete;
using Entities.DTOs;
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
            return new SuccessResult();
        }

        public IResult Delete(int userId)
        {
            User user = _userDal.Get(u => u.Id == userId);
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccesDataResult<User>(_userDal.Get(u => u.Id==id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            var user = _userDal.Get(u=> u.Email ==email);
            if(user is null)
            {
                return new SuccesDataResult<User>(Messages.MailNotFound);

            }
            return new SuccesDataResult<User>(user);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccesDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(UpdateUserDto user)
        {
            User entity = _userDal.Get(e => e.Email ==user.Email);
            if(entity is null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Email = user.Email;
            _userDal.Update(entity);
            return new SuccessResult();
        }

        public IResult UpdatePassword(PasswordUpdateDto password)
        {
           var userToCheck = GetByMail(password.Email);
            if (userToCheck is null)
            {
                return new ErrorResult(Messages.UserNotFound);

            }
            if (!HashingHelper.VerifyPasswordHash(password.OldPassword, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorResult();

            }

            byte[] passwordhash,passwordSalt;
            HashingHelper.CreatePasswordHash(password.NewPassword, out passwordhash, out passwordSalt);

            userToCheck.Data.PasswordHash = passwordhash;
            userToCheck.Data.PasswordSalt = passwordSalt;
            _userDal.Update(userToCheck.Data);

            return new SuccessResult();
        }
    }
}
