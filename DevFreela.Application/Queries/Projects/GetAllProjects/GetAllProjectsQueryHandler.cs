using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.Projects.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;
        public GetAllProjectsQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _dbContext.Projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToListAsync();

            return projects;
        }
    }
}
