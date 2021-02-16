using Business.Abstract;
using Business.Constant;
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

        public IResult Add(Rental obj)
        {
            var resultCars = _rentalDal.GetAll(v => v.CarId == obj.CarId);
            //Burada kiralanacak arabanın id'si veritabanında başka bir kirada kullanılıp kullanılmadığı kotrol edildikten sonra
            //returndate'in boş olup olmadığı kontrol ediliyor.
            foreach (var item in resultCars)
            {
                if (item.CarId==obj.CarId && item.ReturnDate==null)
                {
                    return new ErrorResult(Messages.AddedError);
                }
            }
            _rentalDal.Add(obj);
            return new SuccessResult(Messages.RentalAdded);
        }

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

        public IResult Update(Rental obj)
        {
            _rentalDal.Update(obj);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
