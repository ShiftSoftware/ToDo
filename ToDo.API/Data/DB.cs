using Microsoft.EntityFrameworkCore;
using ShiftSoftware.ShiftIdentity.Dashboard.AspNetCore.Data;

namespace ToDo.API.Data
{
    public class DB : ShiftIdentityDB
    {
        public DB(DbContextOptions option) : base(option)
        {
        }

        public DbSet<Entities.ToDo> ToDos { get; set; }

        public DbSet <Entities.Project> Projects { get; set; }
    }
}
