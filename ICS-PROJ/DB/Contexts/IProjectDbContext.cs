using DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace DB.Contexts
{
    public interface IProjectDbContext
    {
        DbSet<UserEntity> UserEntities { get; }
        DbSet<CarEntity> CarEntities { get; }
        DbSet<RideEntity> RideEntities { get; }
    }
}
