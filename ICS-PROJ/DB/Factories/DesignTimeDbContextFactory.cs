using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DB.Contexts;

namespace DB.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProjectDbContext>
    {
        public ProjectDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ProjectDbContext> builder = new();
            builder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog = Project;
                MultipleActiveResultSets = True;
                Integrated Security = True; ");

            return new ProjectDbContext(builder.Options);
        }
    }
}