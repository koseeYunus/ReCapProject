using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal: IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand> {
            new Brand{Id=1, BrandName="Mercedes"},
            new Brand{Id=2, BrandName="Renault"},
            new Brand{Id=3, BrandName="Citreon"}
            };
        }
        public void Add(Brand obj)
        {
            _brands.Add(obj);
        }

        public void Delete(Brand obj)
        {
            _brands.Remove(_brands.SingleOrDefault(b => b.Id == obj.Id));
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return _brands;
        }

        public void Update(Brand obj)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.Id == obj.Id);
            brandToUpdate.BrandName = obj.BrandName;
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public Brand GetById(int id)
        {
            //Id si uyuşan markayı gönderir.
            return _brands.SingleOrDefault(b => b.Id == id);
        }
    }
}
