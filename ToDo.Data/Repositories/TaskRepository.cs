using AutoMapper;
using ShiftSoftware.ShiftEntity.Core;
using ShiftSoftware.ShiftEntity.EFCore;
using ShiftSoftware.ShiftEntity.Web.Services;
using ToDo.Shared.DTOs.Task;

namespace ToDo.Data.Repositories
{
    public class TaskRepository :
        ShiftRepository<DB, Entities.Task, TaskListDTO, TaskDTO, TaskDTO>,
        IShiftRepositoryAsync<Entities.Task, TaskListDTO, TaskDTO>
    {
        private AzureStorageService azureStorageService;

        public TaskRepository(DB db, AzureStorageService azureStorageService, IMapper mapper) : base(db, db.Tasks, mapper)
        {
            this.azureStorageService = azureStorageService;
        }

        public override ValueTask<TaskDTO> ViewAsync(Entities.Task entity)
        {
            var dto = mapper.Map<TaskDTO>(entity);
            dto.Files.ForEach(f =>
            {
                f.Url = azureStorageService.GetSignedURL(f.Blob);
            });
            return new ValueTask<TaskDTO>(dto);
        }
    }
}
