using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.Skills.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
    }
}
