using Randomizer.DBAdapter.Migrations;
using Randomizer.Models;
using System.Data.Entity;

namespace Randomizer.DBAdapter
{
    internal class RandomizerDBContext : DbContext
    {
        public RandomizerDBContext() : base("NewRandomizerDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RandomizerDBContext, Configuration>(true));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Query> Queries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new Query.QueryEntityConfiguration());
        }
    }
}
