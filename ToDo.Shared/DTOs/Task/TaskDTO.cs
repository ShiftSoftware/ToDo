using ShiftSoftware.ShiftEntity.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Shared.DTOs.Comment;
using ToDo.Shared.Enums;

namespace ToDo.Shared.DTOs.Task
{
    public class TaskDTO : ShiftEntityDTO
    {
        [_TaskHashId]
        public override string? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public _TaskStatus Status { get; set; } = _TaskStatus.New;
        public ShiftEntitySelectDTO? AssignedTo { get; set; }
        public DateTime? DueDate { get; set; }
        [_TaskHashId]
        public string? ParentTaskId { get; set; }
        public List<TaskListDTO>? ChildTasks { get; set; }
        public List<CommentDTO>? Comments { get; set; }
        public List<ShiftFileDTO> Files { get; set; } = new();
    }
}
