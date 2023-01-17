using Microsoft.EntityFrameworkCore;
using SvinefarmAPI.Model;
using SvinefarmAPI.Repository;
using Xunit;

namespace SvinefarmAPI.UnitTests.Repositories
{
	public class LightRepositoryTests
	{
		private readonly DbContextOptions<ThePigFarmContext> _options;
		private readonly ThePigFarmContext _context;
		private readonly LightRepository _repository;

		public LightRepositoryTests()
		{
			_options = new DbContextOptionsBuilder<ThePigFarmContext>()
				.UseInMemoryDatabase(databaseName: "ThePigFarmProjectLight")
				.Options;

			_context = new(_options);

			_repository = new(_context);
		}

		[Fact]
		public async void CreateLightLog_ShouldReturnLightLog()
		{
			//Arrange
			await _context.Database.EnsureDeletedAsync();
			await _context.SaveChangesAsync();

			int expectedId = 1;
			LightLogRequest newLightLog = new()
			{
				Leveloflight = 75,
				Timeoflog = DateTime.UtcNow,
				Lightlevelinstable = 1
			};




			//Act

			var result = await _repository.CreateLightLog(newLightLog);
			//Assert
			Assert.NotNull(result);
			Assert.IsType<Lightlog>(result);
			Assert.Equal(expectedId, result.Id);
		}
	}
}
