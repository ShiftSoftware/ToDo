using ShiftSoftware.ShiftEntity.Model.Dtos;
using ToDo.Shared.DTOs.Comment;
using ToDo.Shared.Enums;
using ShiftSoftware.ShiftEntity.Model.HashId;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace ToDo.Shared.DTOs.Task
{
    public class TaskDTO : ShiftEntityDTO
    {
        [_TaskHashId]
        public override string? ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public _TaskStatus Status { get; set; } = _TaskStatus.New;
        [UserHashIdConverter, Required]
        public ShiftEntitySelectDTO? AssignedTo { get; set; }
        [Required]
        public DateTime? DueDate { get; set; }
        [_TaskHashId]
        public string? ParentTaskId { get; set; }
        [Required]
        public List<TaskListDTO>? ChildTasks { get; set; }
        [Required]
        public List<CommentDTO>? Comments { get; set; }
        [Required]
        public List<ShiftFileDTO> Files { get; set; } = new();
    }

    public class ProductDTOValidator : AbstractValidator<TaskDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("You must enter Product Description");
        }
    }
}
