using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        public readonly IUserRepository _repository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            string passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);

            await _repository.AddAsync(user);
  
            return user.Id;
        }
    }
}