using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer obj)
        {
            _customerDal.Add(obj);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Customer obj)
        {
            _customerDal.Delete(obj);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.SuccessListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id),Messages.SuccessListed);
        }

        public IResult Update(Customer obj)
        {
            _customerDal.Update(obj);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
