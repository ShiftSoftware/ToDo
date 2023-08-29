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
        public string Description { get; set; } = string.Empty;
        public _TaskStatus Status { get; set; } = _TaskStatus.New;
        [UserHashIdConverter, Required]
        public ShiftEntitySelectDTO? AssignedTo { get; set; }
        public DateTime? DueDate { get; set; }
        [_TaskHashId]
        public string? ParentTaskId { get; set; }
        public List<TaskListDTO>? ChildTasks { get; set; }
        public List<CommentDTO>? Comments { get; set; }
        public List<ShiftFileDTO>? Files { get; set; }
    }

    public class ProductDTOValidator : AbstractValidator<TaskDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("You must enter Product Description");

            RuleFor(p => p.Files)
                .NotEmpty().WithMessage("Must not be empty");
        }
    }
}
