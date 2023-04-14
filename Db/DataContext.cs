using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace central_fish_agency_dotnet.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<BoatsModel> Boats => Set<BoatsModel>();
        public DbSet<User> Users => Set<User>();
    }
}