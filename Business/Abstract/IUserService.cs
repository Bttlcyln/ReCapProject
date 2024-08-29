using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        //-----SİLİNCEK------
        //List<User> GetAll();  
        //User GetById(int userId);
        //IResult Add(User user);
        //IResult Update(User user);
        //IResult Delete(int userId);

        //List<OperationClaim> GetClaims(User user);
        //void Add(User user);
        //User GetByMail(string email);

        //IDataResult List<OperationClaim> GetClaims(User user);
        //void Add(User user);
        //IDataResult<User>  GetByMail(string email);
        //IDataResult<User> GetById(int id);


      
       
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult Add(User user);
        IResult Delete(int userId);
        IResult Update(UpdateUserDto user);
        IResult UpdatePassword(PasswordUpdateDto password);


    }
}
