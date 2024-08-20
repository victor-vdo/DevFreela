using MediatR;

namespace DevFreela.Application.Commands.Projects.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public DeleteProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
