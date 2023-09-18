using ShiftSoftware.ShiftFrameworkTestingTools;
using ToDo.Shared.DTOs.ToDo;
using ToDo.Shared.Enums;

namespace ToDo.Test.Tests.ToDo;

[TestCaseOrderer(Constants.OrdererTypeName, Constants.OrdererAssemblyName)]
[Collection("API Collection")]
public class Basic : BasicTest<ToDoDTO, ToDoListDTO>
{
    static ToDoDTO CreatedItem = default!;

    static string title = "ToDo 1";
    static string description = "ToDo Item 1";
    static ToDoStatus status = ToDoStatus.New;

    public Basic(CustomWebApplicationFactory factory, ITestOutputHelper output) : base("ToDo", "ToDo", factory.CreateClient(), output)
    {

    }

    public static ToDoDTO GenerateSampleDTO(ToDoDTO? existingDto = null)
    {
        var dto = new ToDoDTO
        {
            Title = title,
            Description = description,
            Status = status
        };

        if (existingDto is not null)
        {
            dto.LastSaveDate = existingDto.LastSaveDate;
            dto.ID = existingDto.ID;
        }

        return dto;
    }

    [Fact(DisplayName = "01. Create"), TestPriority(1)]
    public async Task _01_Create()
    {
        var item = await PostOrPut(null, GenerateSampleDTO(), true, true);

        CreatedItem = item!;

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
        var item = await base.Get(CreatedItem.ID!);

        Assert.Equal(title, item.Title);
    }

    [Fact(DisplayName = "05. Put"), TestPriority(5)]
    public async Task _05_Put()
    {
        var dto = GenerateSampleDTO(CreatedItem);

        dto.Title = $"{title} - Updated";
        dto.Description = $"{description} - Updated";
        dto.Status = ToDoStatus.InProgress;

        var item = await PostOrPut(CreatedItem.ID!, dto);

        Assert.Multiple(
            () => Assert.Equal(dto.Title, item.Title),
            () => Assert.Equal(dto.Description, item.Description),
            () => Assert.Equal(dto.Status, item.Status)
        );
    }

    [Fact(DisplayName = "06. Get Revisions"), TestPriority(6)]
    public async Task _06_GetRevisions()
    {
        var revisions = await base.RevisionList(CreatedItem.ID!);

        Assert.True(revisions!.Count > 0);
    }

    [Fact(DisplayName = "07. Delete"), TestPriority(7)]
    public async Task _07_Delete()
    {
        var item = await base.Delete(CreatedItem.ID!);

        Assert.True(item!.IsDeleted);
    }
}
