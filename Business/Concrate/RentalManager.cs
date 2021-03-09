using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental obj)
        {
            IResult result= BusinessRules.Run( CheckIfTheCarIsRented(obj));

            if (result!=null)
            {
                return result;
            }
            _rentalDal.Add(obj);
            return new SuccessResult(Messages.RentalAdded);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Delete(Rental obj)
        {
            _rentalDal.Delete(obj);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.SuccessListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(g=> g.Id==id),Messages.SuccessListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            try
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),Messages.SuccessListed);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<RentalDetailDto>>(Messages.ListedError);
            }          
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental obj)
        {
            _rentalDal.Update(obj);
            return new SuccessResult(Messages.SuccessUpdated);
        }


        private IResult CheckIfTheCarIsRented(Rental rental)
        {
            if (_rentalDal.GetAll(r=> r.CarId==rental.CarId).Count>0 && rental.ReturnDate==null)
            {
                return new ErrorResult(Messages.AddedError);
            }
            return new SuccessResult();
        }
    }
}
