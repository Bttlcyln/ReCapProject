﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentAdded);
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.PaymentDeleted);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccesDataResult<List<Payment>>(_paymentDal.GetAll(),Messages.PaymentListed);
        }

        public IDataResult<Payment> GetById(int id)
        {
            return new SuccesDataResult<Payment>(_paymentDal.Get(p=> p.Id ==id));
        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
           return new SuccessResult(Messages.PaymentUpdated);
        }
    }
}
