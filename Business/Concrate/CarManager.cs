using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car obj)
        {
            //return new ErrorResult(Messages.CarValidateError);

            _carDal.Add(obj);
            return new SuccessResult(Messages.CarAdded);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car obj)
        {
            if (DateTime.Now.Hour==00)
            {
                return new ErrorResult(Messages.AddedError);
            }
            _carDal.Delete(obj);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByModelYear(short year)
        {
            if (year < 1900)
            {
                return new ErrorDataResult<List<Car>>(Messages.ListedError);
            }
            var getAllByModel = _carDal.GetAll(c => c.ModelYear == year);
            return new SuccessDataResult<List<Car>>(getAllByModel);
        }

        public IDataResult<List<Car>> GetAllBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=> c.BrandId==brandId));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetAllColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.ColorId==colorId));
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car obj)
        {
            return new SuccessDataResult<Car>(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.SuccessListed);
        }
    }
}
