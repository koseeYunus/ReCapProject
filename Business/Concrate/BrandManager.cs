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
    public class BrandManager: IBrandService 
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand obj)
        {
            if (obj.BrandName.Length < 2)
            {
                new ErrorResult(Messages.BrandAdded);
            }
            _brandDal.Add(obj);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand obj)
        {
            _brandDal.Delete(obj);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            //Burada id'leri uyuşan marka var ise brandResult'a atanıyor.
            var brandResult = _brandDal.Get(b => b.Id == id);
            if (brandResult==null)
            {
                //Eğer brandResult null ise geriye hata gönderiliyor.
                return new ErrorDataResult<Brand>(Messages.ListedError);
            }
            //if çalışmaz ise id'si uyuşan marka geri gönderiliyor.
            return new SuccessDataResult<Brand>(brandResult);
        }

        public IResult Update(Brand obj)
        {
            _brandDal.Update(obj);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
