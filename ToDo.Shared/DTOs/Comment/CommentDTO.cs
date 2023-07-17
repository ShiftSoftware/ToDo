using ShiftSoftware.ShiftEntity.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Shared.DTOs.Task;

namespace ToDo.Shared.DTOs.Comment
{
    public class CommentDTO : ShiftEntityDTO
    {
        [_TaskHashId]
        public override string? ID { get; set; }
        public string Text { get; set; }
        public string TaskId { get; set; }
    
    }
}
