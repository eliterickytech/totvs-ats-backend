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
    using Totvs.ATS.Tests.FakeData;
    using Totvs.ATS.Domain;

    public class VacancyServiceTests
    {
        private readonly Mock<IVacancyRepository> _vacancyRepositoryMock = new Mock<IVacancyRepository>();
        private readonly Mock<IBaseNotification> _baseNotificationMock = new Mock<IBaseNotification>();

        [Fact]
        public async Task AddAsync_ShouldReturnTrue_WhenInputIsValid()
        {
            var service = new VacancyService(_vacancyRepositoryMock.Object, _baseNotificationMock.Object);
            
            var faker = new VacancyAddInputFaker();

            var input = faker.Generate();

            var result = await service.AddAsync(input);

            Assert.True(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnFalse_WhenVacancyNotFound()
        {
            var service = new VacancyService(_vacancyRepositoryMock.Object, _baseNotificationMock.Object);

            var faker = new VacancyUpdateInputFaker();

            var input = faker.Generate();

            _vacancyRepositoryMock.Setup(x => x.GetByIdAsync(input.Id)).ReturnsAsync((Vacancy)null);

            var result = await service.UpdateAsync(input);

            Assert.False(result);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnFalse_WhenVacancyNotFound()
        {
            var service = new VacancyService(_vacancyRepositoryMock.Object, _baseNotificationMock.Object);
            var id = Guid.NewGuid();

            _vacancyRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync((Vacancy)null);

            var result = await service.RemoveAsync(id);

            Assert.False(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenVacancyNotFound()
        {
            var service = new VacancyService(_vacancyRepositoryMock.Object, _baseNotificationMock.Object);
            var id = Guid.NewGuid();

            _vacancyRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync((Vacancy)null);

            var result = await service.GetByIdAsync(id);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoVacancies()
        {
            var service = new VacancyService(_vacancyRepositoryMock.Object, _baseNotificationMock.Object);

            _vacancyRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Vacancy>());

            var result = await service.GetAllAsync();
            Assert.Empty(result);
        }

    }
}