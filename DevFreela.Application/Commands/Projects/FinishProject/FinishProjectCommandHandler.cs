using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Projects.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        public readonly IProjectRepository _repository;

        public FinishProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);
            project.Finish();
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
