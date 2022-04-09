using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DB.Contexts;

namespace DB.Factories
{
    public class SqlServerDbContextFactory : IDbContextFactory<ProjectDbContext>
    {
        private readonly string _connectionString;

        public SqlServerDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ProjectDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            //optionsBuilder.LogTo(System.Console.WriteLine); //Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
            //optionsBuilder.EnableSensitiveDataLogging();

            return new ProjectDbContext(optionsBuilder.Options);
        }
    }
}