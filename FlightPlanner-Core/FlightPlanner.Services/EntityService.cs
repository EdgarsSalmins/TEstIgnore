using FlightPlanner.Core.Services;
using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Core.Models;
using FlightPlanner.Data;

namespace FlightPlanner.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(IFlightPlannerDbContext context) : base(context)
        {
        }

        public IQueryable<T> Query() => Query<T>();

        public IQueryable<T> QueryById(int id) => QueryById<T>(id);

        public IEnumerable<T> Get() => Get<T>();

        public T GetById(int id) => GetById<T>(id);

        public ServiceResult Create(T entity) => Create<T>(entity);


        public ServiceResult Update(T entity) => Update<T>(entity);

        public ServiceResult Delete(T entity) => Delete<T>(entity);

        public bool Exists(int id) => Exists<T>(id);
    }
}
