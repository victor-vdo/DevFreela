using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.Users.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o mesmo algoritmo para criar o hash da senha
            string password = _authService.ComputeSha256Hash(request.Password);

            // Buscar no BD um user que tenha o e-mail e senha em formato 
            User user = await _userRepository.GetyByEmailAndPasswordAsync(request.Email, password);
            
            // Se não existir, erro no login
            if (user == null)
            {
                return null;
            }

            // Se existir, gera o token
            var token = _authService.GenerateJwtToken(user.Email, user.Role);
            return new LoginUserViewModel(user.Email, token);
        }
    }
}