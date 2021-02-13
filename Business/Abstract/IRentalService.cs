using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService: IEquatableService<Rental>
    {
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
