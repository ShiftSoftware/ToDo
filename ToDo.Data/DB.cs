using Microsoft.EntityFrameworkCore;
using ShiftSoftware.ShiftIdentity.Dashboard.AspNetCore.Data;
using ToDo.Data.Entities;

namespace ToDo.Data
{
    public class DB : ShiftIdentityDB
    {
        public DB(DbContextOptions option) : base(option)
        {
        }

        public DbSet<Entities.ToDo> ToDos { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }

        public DbSet<Project> Projects { get; set; }
    }
}
