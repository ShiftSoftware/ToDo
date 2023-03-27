using Microsoft.EntityFrameworkCore;
using ShiftSoftware.ShiftEntity.Core;

namespace ToDo.API.Data
{
    public class DB : ShiftDbContext
    {
        public DB(DbContextOptions option) : base(option)
        {
        }

        public DbSet<Entities.ToDo> ToDos { get; set; }
    }
}
