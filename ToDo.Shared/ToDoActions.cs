using ShiftSoftware.TypeAuth.Core;
using ShiftSoftware.TypeAuth.Core.Actions;

namespace ToDo.Shared;


[ActionTree("ToDo", "ToDo App Actions")]
public class ToDoActions
{
    public readonly static ReadWriteDeleteAction ToDo = new ReadWriteDeleteAction("ToDo");
}
