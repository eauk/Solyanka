using System.Configuration;
using System.Data.Entity;
using Solyanka.Domain.Persistance;

namespace Solyanka.Domain
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(ConnectionString)
        {
        }

        public DbSet<User> Users { get; set; }

        private static string ConnectionString { get { return ConfigurationManager.ConnectionStrings["SolyankaConnectString"].ConnectionString; } }
    }
}
