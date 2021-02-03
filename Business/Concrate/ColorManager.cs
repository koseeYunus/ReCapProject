using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class ColorManager : IEquatableService<Color>
    {
        IEquatableDal<Color> _equatableDal;

        public ColorManager(IEquatableDal<Color> equatableDal)
        {
            _equatableDal = equatableDal;
        }
        public void Add(Color obj)
        {
            _equatableDal.Add(obj);
        }

        public void Delete(int id)
        {
            _equatableDal.Delete(id);
        }

        public List<Color> GetAll()
        {
            return _equatableDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _equatableDal.GetById(id);
        }

        public void Update(Color obj)
        {
            _equatableDal.Update(obj);
        }
    }
}
