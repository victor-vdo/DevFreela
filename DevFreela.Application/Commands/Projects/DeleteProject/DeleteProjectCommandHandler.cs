using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Projects.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        public readonly IProjectRepository _repository;

        public DeleteProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);
            project.Cancel();

            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
