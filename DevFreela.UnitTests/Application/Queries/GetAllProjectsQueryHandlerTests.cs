using DevFreela.Application.Queries.Projects.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{

    public class GetAllProjectsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Nome do Teste 1","Descrição do Teste 1", 1, 31, 10000),
                new Project("Nome do Teste 2","Descrição do Teste 2", 2, 32, 20000),
                new Project("Nome do Teste 3","Descrição do Teste 3", 3, 33, 30000),
                new Project("Nome do Teste 4","Descrição do Teste 4", 4, 34, 40000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result)
                .Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            // Act
            var projectViewMoldelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewMoldelList);
            Assert.NotEmpty(projectViewMoldelList);
            Assert.Equal(projects.Count, projectViewMoldelList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);

        }
    }
}
