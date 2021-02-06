using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEquatableService<T>
    {
        void Add(T obj);
        void Delete(T obj);
        void Update(T obj);
        List<T> GetAll();
        T GetById(int id);
    }
}
