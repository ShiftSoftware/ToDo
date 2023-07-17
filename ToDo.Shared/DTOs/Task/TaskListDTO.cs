using ShiftSoftware.ShiftEntity.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Shared.Enums;

namespace ToDo.Shared.DTOs.Task
{
    public class TaskListDTO : ShiftEntityListDTO
    {
        [_TaskHashId]
        public override string? ID { get; set; }
        public string Name { get; set; }
        public _TaskStatus Status { get; set; }
        public object? AssignedTo { get; set; }
        [_TaskHashId]
        public string? ParentTaskId { get; set; }
    }
}
