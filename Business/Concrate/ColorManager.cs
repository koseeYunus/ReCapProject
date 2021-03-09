using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color obj)
        {

            _colorDal.Add(obj);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color obj)
        {
            IResult result = BusinessRules.Run(CheckIfColorNameExists(obj.ColorName));

            if (result!=null)
            {
                return new ErrorResult(Messages.IdError);
            }
            _colorDal.Delete(obj);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color obj)
        {
            _colorDal.Update(obj);
            return new SuccessResult(Messages.ColorUpdated);
        }


        private IResult CheckIfColorNameExists(string colorName)
        {
            var result = _colorDal.GetAll(c=> c.ColorName==colorName).Count > 0;
            if (result)
            {
                return new ErrorResult(Messages.AddedError);
            }
            return new SuccessResult();
        }

    }
}
