using ShiftSoftware.TypeAuth.Core;
using ShiftSoftware.TypeAuth.Core.Actions;

namespace ToDo.Shared;


[ActionTree("ToDo", "ToDo App Actions")]
public class ToDoActions
{
    public readonly static ReadWriteDeleteAction ToDo = new ReadWriteDeleteAction("ToDo");
    public readonly static ReadWriteDeleteAction Project = new ReadWriteDeleteAction("Project");
    public readonly static ReadWriteDeleteAction Task = new ReadWriteDeleteAction("Task");

    public readonly static DecimalAction MaxUploadSizeInMegaBytes = new DecimalAction("Max Upload Size", null, 0, 10m);
    public readonly static ReadWriteDeleteAction UploadFiles = new ReadWriteDeleteAction("Upload Files");

    [ActionTree("Data Level Access", "Data Level or Row-Level Access")]
    public class DataLevelAccess
    {
        public readonly static DynamicReadWriteDeleteAction Projects = new DynamicReadWriteDeleteAction("Projects");
    }
}
