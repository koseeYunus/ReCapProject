using Business.Abstract;
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

        public void Add(Color obj)
        {
            _colorDal.Add(obj);
        }

        public void Delete(Color obj)
        {
            _colorDal.Delete(obj);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(c=> c.Id==id);
        }

        public void Update(Color obj)
        {
            _colorDal.Update(obj);
        }
    }
}
