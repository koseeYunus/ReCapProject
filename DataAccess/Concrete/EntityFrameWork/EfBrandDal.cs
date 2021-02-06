using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand obj)
        {
            using (ReCapContext context=new ReCapContext())
            {
                var addedEntity = context.Entry(obj);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

                //context.Brands.Add(obj);
                //context.SaveChanges();
            }
        }

        public void Delete(Brand obj)
        {
            using (ReCapContext context=new ReCapContext())
            {
                var deletedEntity = context.Entry(obj);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (ReCapContext context=new ReCapContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand obj)
        {
            using (ReCapContext context=new ReCapContext())
            {
                var updatedEntity = context.Entry(obj);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
