using ShiftSoftware.ShiftEntity.Model.HashId;

namespace ToDo.Shared.DTOs.ToDo;

internal class _ToDoHashId : JsonHashIdConverterAttribute<_ToDoHashId>
{
    public _ToDoHashId() : base(5)
    { }
}
