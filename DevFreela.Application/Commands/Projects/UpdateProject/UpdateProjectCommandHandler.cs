using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Projects.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        public readonly IProjectRepository _repository;
        public UpdateProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);
            project.Update(request.Title, request.Description, request.TotalCost);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
