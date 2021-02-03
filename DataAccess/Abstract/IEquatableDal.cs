using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEquatableDal<T>
    {
        void Add(T obj);
        void Delete(int id);
        void Update(T obj);
        List<T> GetAll();
        T GetById(int id);
    }
}
