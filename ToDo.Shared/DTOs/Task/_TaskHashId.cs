using ShiftSoftware.ShiftEntity.Model.HashId;

namespace ToDo.Shared.DTOs.Task;

internal class _TaskHashId : JsonHashIdConverterAttribute<_TaskHashId>
{
    public _TaskHashId() : base(8)
    { }
}
