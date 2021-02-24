using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer obj)
        {
            _customerDal.Add(obj);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [ValidationAspect(typeof(CustomerValidator))]
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

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer obj)
        {
            _customerDal.Update(obj);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
