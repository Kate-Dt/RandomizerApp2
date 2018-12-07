using System.Data.Entity.Migrations;

namespace Randomizer.DBAdapter.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RandomizerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}