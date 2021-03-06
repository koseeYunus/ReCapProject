﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=25000, ModelYear=2002, Description="Hiç bir sorunu yoktur."},
            new Car{Id=2, BrandId=1, ColorId=2, DailyPrice=38000, ModelYear=2007, Description="Ağır kazası vardır"},
            new Car{Id=3, BrandId=2, ColorId=1, DailyPrice=55000, ModelYear=2011, Description="Dosta gider."},
            new Car{Id=4, BrandId=3, ColorId=3, DailyPrice=19000, ModelYear=1998, Description="Komple boyalı."},
            new Car{Id=5, BrandId=2, ColorId=2, DailyPrice=175000, ModelYear=2021, Description="Sıfır araba."},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car obj)
        {
            _cars.Remove(_cars.SingleOrDefault(c=> c.Id==obj.Id));
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }       

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }        

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.Id==car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            //Id si uyuşan arabayı gönderir.
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
