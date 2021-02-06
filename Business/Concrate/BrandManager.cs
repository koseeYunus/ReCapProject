using Business.Abstract;
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

        public void Add(Brand obj)
        {
            _brandDal.Add(obj);
        }

        public void Delete(Brand obj)
        {
            _brandDal.Delete(obj);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(b=> b.Id==id);
        }

        public void Update(Brand obj)
        {
            _brandDal.Update(obj);
        }
    }
}
