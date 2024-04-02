namespace Totvs.ATS.Tests.Services
{
    using Xunit;
    using Moq;
    using System;
    using System.Threading.Tasks;
    using Totvs.ATS.Service;
    using Totvs.ATS.Domain.Interfaces.Repository;
    using Totvs.ATS.Service.Input;
    using Totvs.ATS.Shared.Interfaces;
    using Totvs.ATS.Domain;
    using Totvs.ATS.Tests.FakeData;

    public class CandidateServiceTests
    {
        private readonly Mock<ICandidateRepository> _candidateRepositoryMock = new Mock<ICandidateRepository>();
        private readonly Mock<IBaseNotification> _baseNotificationMock = new Mock<IBaseNotification>();
        private readonly CandidateAddInputFaker _candidateAddInputFaker = new CandidateAddInputFaker();
        private readonly CandidateUpdateInputFaker _candidateUpdateInputFaker = new CandidateUpdateInputFaker();


        [Fact]
        public async Task AddAsync_ShouldReturnTrue_WhenInputIsValid()
        {

            var service = new CandidateService(_candidateRepositoryMock.Object, _baseNotificationMock.Object);
            var input = _candidateAddInputFaker.Generate();

            _candidateRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Candidate>())).Returns(Task.CompletedTask);
            _candidateRepositoryMock.Setup(x => x.GetByIdAsync(input.Id)).ReturnsAsync(new Candidate());

            var result = await service.AddAsync(input);

            Assert.True(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnFalse_WhenCandidateNotFound()
        {
            // Arrange
            var service = new CandidateService(_candidateRepositoryMock.Object, _baseNotificationMock.Object);
            var input = _candidateUpdateInputFaker.Generate();

            _candidateRepositoryMock.Setup(x => x.GetByIdAsync(input.Id)).ReturnsAsync((Candidate)null);

            var result = await service.UpdateAsync(input);

            Assert.False(result);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnFalse_WhenCandidateNotFound()
        {
            var service = new CandidateService(_candidateRepositoryMock.Object, _baseNotificationMock.Object);
            var id = Guid.NewGuid();

            _candidateRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync((Candidate)null);

            var result = await service.RemoveAsync(id);

            Assert.False(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCandidate_WhenCandidateExists()
        {
            // Arrange
            var service = new CandidateService(_candidateRepositoryMock.Object, _baseNotificationMock.Object);
            var id = Guid.NewGuid();
            var expectedCandidate = new Candidate { Id = id };

            _candidateRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(expectedCandidate);

            // Act
            var result = await service.GetByIdAsync(id);

            Assert.Null(result);
        }
    }
}
