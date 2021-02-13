using Core.Entities;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEquatableService<T> where T: class, IEntity, new()
    {
        IResult Add(T obj);
        IResult Delete(T obj);
        IResult Update(T obj);
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
    }
}
