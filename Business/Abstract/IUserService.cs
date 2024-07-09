using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
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

        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
