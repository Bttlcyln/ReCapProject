using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCar;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(int customerId)
        {
            return new SuccesDataResult<List<Customer>>(Messages.CustomerDeleted);
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer GetById(int customerId)
        {
            return _customerDal.Get(c=>c.CustomerUserId==customerId);
        }

        public IResult Update(Customer customer)
        {
            return new SuccessResult(Messages.CustomeUpdated);
        }
    }
}
