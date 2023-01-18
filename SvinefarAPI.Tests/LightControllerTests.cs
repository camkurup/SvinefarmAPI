using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SvinefarmAPI;

namespace SvinefarAPI.Tests
{
    public class LightControllerTests
    {
        private readonly DbContextOptions<ThePigFarmContext> _options;
        private readonly ThePigFarmContext _context;
        private readonly LightRepository _repository;

        public LightControllerTests() 
        {
            _options = new DbContextOptionsBuilder<ThePigFarmContext>()
                .UseInMemoryDatabase(databaseName: "ThePigFarm")
                .Options;

            _context = new(_options);

            _repository = new(_context);
        }
        public void GetAllLightLogs_ShouldReturnListOfLightLogs()
        {
            //Arrange


            //Act

            //Assert
        }
    }
}
