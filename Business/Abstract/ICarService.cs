using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService: IEquatableService<Car>
    {
        IDataResult<List<Car>> GetAllBrandId(int brandId);
        IDataResult<List<Car>> GetAllColorId(int colorId);
        IDataResult<List<Car>> GetAllByModelYear(short year);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
