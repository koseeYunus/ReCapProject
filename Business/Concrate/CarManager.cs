using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class CarManager : IEquatableService<Car>
    {
        IEquatableDal<Car> _equatableDal;

        public CarManager(IEquatableDal<Car> equatableDal)
        {
            _equatableDal = equatableDal;

        }
        public void Add(Car obj)
        {
            _equatableDal.Add(obj);
        }

        public void Delete(int id)
        {
            _equatableDal.Delete(id);
        }

        public List<Car> GetAll()
        {
            return _equatableDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _equatableDal.GetById(id);
        }

        public void Update(Car obj)
        {
            _equatableDal.Update(obj);
        }
    }
}
