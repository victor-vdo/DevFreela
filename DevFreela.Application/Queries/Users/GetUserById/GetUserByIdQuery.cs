using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
