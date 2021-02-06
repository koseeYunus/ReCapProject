using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
        public void Add(Car obj)
        {
            _carDal.Add(obj);
        }

        public void Delete(Car obj)
        {
            _carDal.Delete(obj);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c=> c.Id==id);
        }

        public void Update(Car obj)
        {
            _carDal.Update(obj);
        }
    }
}
