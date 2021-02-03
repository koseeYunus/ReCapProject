using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class BrandManager : IEquatableService<Brand>
    {
        IEquatableDal<Brand> _equatableDal;

        public BrandManager(IEquatableDal<Brand> equatableDal)
        {
            _equatableDal = equatableDal;
        }

        public void Add(Brand obj)
        {
            _equatableDal.Add(obj);
        }

        public void Delete(int id)
        {
            _equatableDal.Delete(id);
        }

        public List<Brand> GetAll()
        {
            return _equatableDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _equatableDal.GetById(id);
        }

        public void Update(Brand obj)
        {
            _equatableDal.Update(obj);
        }
    }
}
