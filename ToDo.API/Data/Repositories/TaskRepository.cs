using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShiftSoftware.EFCore.SqlServer;
using ShiftSoftware.ShiftEntity.Core;
using ShiftSoftware.ShiftEntity.Web.Services;
using System.Text.Json;
using ToDo.Shared.DTOs.Task;

namespace ToDo.API.Data.Repositories
{
    public class TaskRepository :
        ShiftRepository<Entities.Task>,
        IShiftRepositoryAsync<Entities.Task, TaskListDTO, TaskDTO>
    {
        private DB db;
        private AzureStorageService azureStorageService;
        public readonly IMapper mapper;

        public TaskRepository(DB db, AzureStorageService azureStorageService, IMapper mapper) : base(db, db.Tasks)
        {
            this.db = db;
            this.azureStorageService = azureStorageService;
            this.mapper = mapper;
        }

        public ValueTask<Entities.Task> CreateAsync(TaskDTO dto, long? userId = null)
        {
            var entity = new Entities.Task();

            this.AssignValue(entity, dto);

            return new ValueTask<Entities.Task>(entity);
        }

        public ValueTask<Entities.Task> DeleteAsync(Entities.Task entity, long? userId = null)
        {
            entity.DeleteShiftEntity(userId);

            return new ValueTask<Entities.Task>(entity);
        }

        public async Task<Entities.Task> FindAsync(long id, DateTime? asOf = null, bool ignoreGlobalFilters = false)
        {
            return await base.FindAsync(id, asOf, ignoreGlobalFilters);
        }

        public IQueryable<TaskListDTO> OdataList(bool ignoreGlobalFilters = false)
        {
            return mapper.ProjectTo<TaskListDTO>(db.Tasks.AsNoTracking());
        }

        public ValueTask<Entities.Task> UpdateAsync(Entities.Task entity, TaskDTO dto, long? userId = null)
        {
            this.AssignValue(entity, dto);

            return new ValueTask<Entities.Task>(entity);
        }

        public ValueTask<TaskDTO> ViewAsync(Entities.Task entity)
        {
            var dto = mapper.Map<TaskDTO>(entity);
            dto.Files.ForEach(f =>
            {
                f.Url = azureStorageService.GetSignedURL(f.Blob);
            });
            return new ValueTask<TaskDTO>(dto);
        }

        public void AssignValue(Entities.Task entity, TaskDTO dto)
        {
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.Status = dto.Status;
            entity.DueDate = dto.DueDate;
            entity.Files = JsonSerializer.Serialize(dto.Files);

            if (dto.ParentTaskId != null)
            {
                entity.ParentTaskId = dto.ParentTaskId.ToLong();
            }

            if (dto.AssignedTo != null)
            {
                entity.AssignedToId = dto.AssignedTo.Value.ToLong();
            }
        }

    }
}
