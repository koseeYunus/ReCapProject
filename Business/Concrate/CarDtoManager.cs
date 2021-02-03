using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class CarDtoManager : ICarDtoService
    {
        ICarDtoDal _carDtoDal;

        public CarDtoManager(ICarDtoDal carDtoDal)
        {
            _carDtoDal = carDtoDal;
        }

        public List<CarDto> GetAll()
        {
            return _carDtoDal.GetAll();
        }
    }
}
