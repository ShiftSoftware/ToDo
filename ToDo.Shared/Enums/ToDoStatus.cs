using System.ComponentModel;

namespace ToDo.Shared.Enums;

public enum ToDoStatus
{
    [Description("New")]
    New = 1,

    [Description("In Progress")]
    InProgress = 2,

    [Description("Completed")]
    Completed = 3
}
