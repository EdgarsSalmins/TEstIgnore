using System;
using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner.Data;

namespace FlightPlanner.Services
{
    public class DbService : IDbService
    {
        private readonly IFlightPlannerDbContext _ctx;

        public DbService(IFlightPlannerDbContext context)
        {
            _ctx = context;
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _ctx.Set<T>();
        }

        public IQueryable<T> QueryById<T>(int id) where T : Entity
        {
            return _ctx.Set<T>().Where(e => e.Id == id);
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            return Query<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _ctx.Set<T>().Find(id);
        }

        public ServiceResult Create<T>(T entity) where T : Entity
        {
            _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();

            return new ServiceResult(true).Set(entity);
        }

        public ServiceResult Update<T>(T entity) where T : Entity
        {
            _ctx.Entry<T>(entity);
            _ctx.SaveChanges();
            return new ServiceResult(true).Set(entity);
        }

        public ServiceResult Delete<T>(T entity) where T : Entity
        {
            _ctx.Set<T>().Remove(entity);
            _ctx.SaveChanges();
            return new ServiceResult(true);
        }

        public bool Exists<T>(int id) where T : Entity
        {
            return _ctx.Set<T>().Any(e => e.Id == id);
        }
    }
}
