using Domain.Model.Entities.SQL;
using Domain.Model.Entities.SQL;
using Microsoft.EntityFrameworkCore;

namespace DrivenAdapters.SQL
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext(DbContextOptions options) : base(options) { }

        public DbSet<TBL_BRAND> Brand { get; set; }
        public DbSet<TBL_EPS> Eps { get; set; }
        public DbSet<TBL_INSURANCE_TYPE> InsuranceType   { get; set; }
        public DbSet<TBL_INSURANCE_VALUES> InsuranceValues { get; set; }
        public DbSet<TBL_LINE> Line { get; set; }
        public DbSet<TBL_PERSON> Person { get; set; }
        public DbSet<TBL_REQUEST> Request { get; set; }
        public DbSet<TBL_VEHICLE> Vehicle { get; set; }
    }
}
