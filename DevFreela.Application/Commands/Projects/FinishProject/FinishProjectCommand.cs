using MediatR;

namespace DevFreela.Application.Commands.Projects.FinishProject
{
    public class FinishProjectCommand : IRequest<Unit>
    {
        public readonly int Id;
        public FinishProjectCommand(int id)
        {
            Id = id;
        }
    }
}
