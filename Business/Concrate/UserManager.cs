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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User obj)
        {
            _userDal.Add(obj);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Delete(User obj)
        {
            _userDal.Delete(obj);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.SuccessListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id),Messages.SuccessListed);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User obj)
        {
            _userDal.Update(obj);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
