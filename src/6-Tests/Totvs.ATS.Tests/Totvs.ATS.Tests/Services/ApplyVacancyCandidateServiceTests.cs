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

    public class ApplyVacancyCandidateServiceTests
    {
        private readonly Mock<ICandidateRepository> _candidateRepositoryMock = new Mock<ICandidateRepository>();
        private readonly Mock<IBaseNotification> _baseNotificationMock = new Mock<IBaseNotification>();
        private readonly ApplyVacancyCandidateInputFaker _applyVacancyCandidateInputFaker = new ApplyVacancyCandidateInputFaker();

        [Fact]
        public async Task AddAsync_ShouldReturnTrue_WhenInputIsValidAndCandidateExists()
        {
            // Arrange
            var service = new ApplyVacancyCandidateService(_candidateRepositoryMock.Object, _baseNotificationMock.Object);
            var input = _applyVacancyCandidateInputFaker.Generate();

            _candidateRepositoryMock.Setup(x => x.GetByIdAsync(input.CandidateId)).ReturnsAsync(new Candidate());
            _candidateRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Candidate>())).Returns(Task.CompletedTask);

            // Act
            var result = await service.AddAsync(input);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnFalse_WhenCandidateNotFound()
        {
            // Arrange
            var service = new ApplyVacancyCandidateService(_candidateRepositoryMock.Object, _baseNotificationMock.Object);
            var input = _applyVacancyCandidateInputFaker.Generate();

            _candidateRepositoryMock.Setup(x => x.GetByIdAsync(input.CandidateId)).ReturnsAsync((Candidate)null);

            // Act
            var result = await service.AddAsync(input);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnFalse_WhenCandidateNotFound()
        {
            // Arrange
            var service = new ApplyVacancyCandidateService(_candidateRepositoryMock.Object, _baseNotificationMock.Object);
            var candidateId = Guid.NewGuid();
            var vacancyId = Guid.NewGuid();

            _candidateRepositoryMock.Setup(x => x.GetByIdAsync(candidateId)).ReturnsAsync((Candidate)null);

            // Act
            var result = await service.RemoveAsync(candidateId, vacancyId);

            // Assert
            Assert.False(result);
        }

    }

}