using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Moq;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        public readonly Project _project;

        public ProjectTests()
        {
            _project = new Project("Nome de Teste", "Descrição de Teste", 1, 2, 10000);
        }

        // Given_When_Then Pattern and AAA Pattern
        [Fact]
        public void ImputProjectOk_StartProject_ReturnProjectStatusInProgress()
        {
            Assert.Equal(ProjectStatusEnum.Created, _project.Status);
            Assert.Null(_project.StartedAt);

            Assert.NotNull(_project.Title);
            Assert.NotEmpty(_project.Title);

            Assert.NotNull(_project.Description);
            Assert.NotEmpty(_project.Description);

            _project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, _project.Status);
            Assert.NotNull(_project.StartedAt);
        }

        [Fact]
        public void ImputProjectOk_CancelProject_ReturnProjectStatusCancelled()
        {
            Assert.Equal(ProjectStatusEnum.Created, _project.Status);
            Assert.Null(_project.StartedAt);

            Assert.NotNull(_project.Title);
            Assert.NotEmpty(_project.Title);

            Assert.NotNull(_project.Description);
            Assert.NotEmpty(_project.Description);

            _project.Cancel();

            Assert.Equal(ProjectStatusEnum.Cancelled, _project.Status);
        }

        [Fact]
        public void ImputProjectOk_FinishProject_ReturnProjectStatusFinished()
        {
            _project.Start();
            Assert.Equal(ProjectStatusEnum.InProgress, _project.Status);

            Assert.NotNull(_project.Title);
            Assert.NotEmpty(_project.Title);

            Assert.NotNull(_project.Description);
            Assert.NotEmpty(_project.Description);

            _project.Finish();

            Assert.Equal(ProjectStatusEnum.Finished, _project.Status);
            Assert.NotNull(_project.StartedAt);
        }

        [Fact]
        public void ImputProjectOk_UpdateProject_ReturnProjectUpdated()
        {
            Assert.NotNull(_project.Title);
            Assert.NotEmpty(_project.Title);

            Assert.NotNull(_project.Description);
            Assert.NotEmpty(_project.Description);

            _project.Update("Teste Title","Teste Description", 20000);

            Assert.Equal("Teste Title", _project.Title);
            Assert.Equal("Teste Description", _project.Description);
            Assert.Equal(20000, _project.TotalCost);
        }

    }
}
