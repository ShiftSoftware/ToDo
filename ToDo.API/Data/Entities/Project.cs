using AutoMapper;
using ShiftSoftware.ShiftEntity.Core;
using ToDo.API.Data.Entities;
using ToDo.Shared.DTOs.Project;

namespace ToDo.API.Data.Entities
{
    [TemporalShiftEntity]
    public class Project : ShiftEntity<Project>
    {
        public string Name { get; set; } = default!;
    }
}