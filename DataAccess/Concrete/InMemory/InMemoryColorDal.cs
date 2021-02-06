using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _color;
        public InMemoryColorDal()
        {
            _color = new List<Color> {
            new Color{Id=1, ColorName="Beyaz"},
            new Color{Id=2, ColorName="Mavi"},
            new Color{Id=3, ColorName="Siyah"}
            };
        }
        public void Add(Color obj)
        {
            _color.Add(obj);
        }


        public void Delete(Color obj)
        {
            _color.Remove(_color.SingleOrDefault(c=>c.Id==obj.Id));
        }     

        public void Update(Color obj)
        {
            Color brandToUpdate = _color.SingleOrDefault(c => c.Id == obj.Id);
            brandToUpdate.ColorName = obj.ColorName;
        }

        public List<Color> GetAll()
        {
            return _color;
        }
        public Color GetById(int id)
        {
            return _color.SingleOrDefault(c => c.Id == id);
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return null;
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            return null;
        }
    }
}
