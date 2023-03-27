using ToDo.Shared.DTOs.ToDo;
using ToDo.Shared.Enums;

namespace ToDo.Test.Tests.ToDo;

[TestCaseOrderer("ToDo.Test.PriorityOrderer", "ToDo.Test")]
[Collection("API Collection")]
public class Basic : BasicTest<ToDoDTO, ToDoListDTO>
{
    static long CreatedItemId;

    static string title = "ToDo 1";
    static string description = "ToDo Item 1";
    static ToDoStatus status = ToDoStatus.New;

    public Basic(CustomWebApplicationFactory<WebMarker> factory, ITestOutputHelper output) : base("ToDo", "ToDo", factory.CreateClient(), output)
    {

    }

    public async Task<ToDoDTO> PostOrPut(long? ID, string title, string description, ToDoStatus status)
    {
        var dto = new ToDoDTO
        {
            Title = title,
            Description = description,
            Status = status
        };

        if (ID == null)
            return await base.Post(dto);
        else
            return await base.Put(ID.Value, dto);
    }

    [Fact(DisplayName = "01. Create"), TestPriority(1)]
    public async Task _01_Create()
    {
        var item = await PostOrPut(
            ID: null,
            title: title,
            description: description,
            status: status
        );

        CreatedItemId = item.ID;

        Assert.Multiple(
            () => Assert.Equal(title, item.Title),
            () => Assert.Equal(description, item.Description),
            () => Assert.Equal(status, item.Status)
        );
    }

    [Fact(DisplayName = "02. List"), TestPriority(2)]
    public async Task _02_List()
    {
        var items = await base.OdataList();

        Assert.Contains(items, x => x.Title == title);
    }

    [Fact(DisplayName = "03. Filter"), TestPriority(3)]
    public async Task _03_Filter()
    {
        var items = await base.OdataList($"?$filter=Title eq 'Random Title'");

        Assert.DoesNotContain(items, x => x.Title == title);
    }

    [Fact(DisplayName = "04. Get"), TestPriority(4)]
    public async Task _04_Get()
    {
        var item = await base.Get(CreatedItemId);

        Assert.Equal(title, item.Title);
    }

    [Fact(DisplayName = "05. Put"), TestPriority(5)]
    public async Task _05_Put()
    {
        var updatedTitle = $"{title} - Updated";
        var updatedDescription = $"{description} - Updated";
        var updatedStatus = ToDoStatus.InProgress;

        var item = await PostOrPut(
            ID: CreatedItemId,
            title: updatedTitle,
            description: updatedDescription,
            status: updatedStatus
        );

        CreatedItemId = item.ID;

        Assert.Multiple(
            () => Assert.Equal(updatedTitle, item.Title),
            () => Assert.Equal(updatedDescription, item.Description),
            () => Assert.Equal(updatedStatus, item.Status)
        );
    }

    [Fact(DisplayName = "07. Get Revisions"), TestPriority(6)]
    public async Task _07_GetRevisions()
    {
        var revisions = await base.RevisionList(CreatedItemId);

        Assert.True(revisions.Count > 0);
    }

    [Fact(DisplayName = "07. Delete"), TestPriority(7)]
    public async Task _07_Delete()
    {
        var item = await base.Delete(CreatedItemId);

        Assert.True(item.IsDeleted);
    }
}
