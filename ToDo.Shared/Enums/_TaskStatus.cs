using System.ComponentModel;

namespace ToDo.Shared.Enums;

public enum _TaskStatus
{
    [Description("New")]
    New = 10,

    [Description("In Progress")]
    InProgress = 20,

    [Description("Completed")]
    Completed = 30,

    [Description("Rejected")]
    Rejected = 40,
}
