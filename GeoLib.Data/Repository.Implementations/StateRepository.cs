using System;
using System.Collections.Generic;
using System.Linq;
using GeoLib.Business.Entities;
using GeoLib.Core;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq.Expressions;

namespace GeoLib.Data
{
    [Export(typeof(IStateRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StateRepository : DataRepositoryBase<State, GeoLibDbContext>, IStateRepository
    {
        public State GetByAbbrivation(string abbrivation)
        {
            using(GeoLibDbContext ctx = new GeoLibDbContext())
            {
                return ctx.ZipStateSet.Where(s => s.Abbreviation.ToUpper() == abbrivation.ToUpper()).FirstOrDefault();
            }
        }
        public IEnumerable<State> GetByPrimaryState(bool isPrimaryState)
        {
            using (GeoLibDbContext ctx = new GeoLibDbContext())
            {
                return ctx.ZipStateSet.Where(s => s.IsPrimaryState == isPrimaryState).ToList();
            }
        }
        protected override DbSet<State> DbSet(GeoLibDbContext context)
        {
            return context.ZipStateSet;
        }
        protected override Expression<Func<State, bool>> Predicate(int id)
        {
            return ctx => ctx.StateId == id;
        }
    }
}
