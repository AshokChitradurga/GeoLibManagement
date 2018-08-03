using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Data
{
    using System.Data.Entity;
    using System.Linq.Expressions;
    using Business.Entities;
    using Core;
    using System.ComponentModel.Composition;

    [Export(typeof(IZipCodeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ZipCodeRepository : DataRepositoryBase<ZipCode, GeoLibDbContext>, IZipCodeRepository
    {
        public IEnumerable<ZipCode> GetByState(string state)
        {
            using (GeoLibDbContext ctx = new GeoLibDbContext())
            {
                return ctx.ZipCodeSet
                    .Include(zipcode => zipcode.State)
                    .Where(e => e.State.Name == state)
                    .ToList();
            }
        }
        public ZipCode GetByZip(string zip)
        {
            using (GeoLibDbContext ctx = new GeoLibDbContext())
            {
                return ctx.ZipCodeSet.Include(zipcode => zipcode.State).Where(e => e.Zip == zip).FirstOrDefault();
            }
        }
        public IEnumerable<ZipCode> GetZipByRange(ZipCode zip, int range)
        {
            using (GeoLibDbContext ctx = new GeoLibDbContext())
            {
                double degrees = range / 0.69;
                return ctx.ZipCodeSet
                          .Include(s => s.State)
                          .Where(e => e.Latitude <= zip.Latitude + degrees && e.Latitude >= zip.Latitude + degrees)
                          .ToList();
            }
        }
        public override IEnumerable<ZipCode> SelectAllRecords()
        {
            using (GeoLibDbContext context = new GeoLibDbContext())
            {
                return context.ZipCodeSet.Include(e => e.State).ToList();
            }
        }
        protected override DbSet<ZipCode> DbSet(GeoLibDbContext context)
        {
            return context.ZipCodeSet;
        }
        protected override Expression<Func<ZipCode, bool>> Predicate(int id)
        {
            return ctx => ctx.ZipCodeId == id;
        }
    }
}
