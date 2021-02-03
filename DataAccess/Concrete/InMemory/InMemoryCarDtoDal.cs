using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDtoDal : ICarDtoDal
    {
        List<CarDto> _carDtos;
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;

        public InMemoryCarDtoDal(List<Car> cars, List<Brand> brands, List<Color> colors)
        {
            _cars = cars;
            _brands = brands;
            _colors = colors;
        }

        public List<CarDto> GetAll()
        {
            _carDtos = (from car in _cars
                        join brand in _brands on car.BrandId equals brand.Id
                        join color in _colors on car.ColorId equals color.Id
                        select new CarDto{
                            Id = car.Id,
                            ColorName = color.ColorName,
                            BrandName = brand.BrandName,
                            DailyPrice = car.DailyPrice,
                            Decription = car.Description,
                            ModelYear = car.ModelYear
                        }
                        ).ToList();

            return _carDtos;
        }

    }
}
