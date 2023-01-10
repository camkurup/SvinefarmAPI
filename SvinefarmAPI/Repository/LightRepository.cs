using Microsoft.EntityFrameworkCore;
using Npgsql;
using SvinefarmAPI.Helpers;
using SvinefarmAPI.Interfaces;
using SvinefarmAPI.Model;

namespace SvinefarmAPI.Repository
{
    public class LightRepository : ILightRepository
	{
        DataContext _dataContext;

        public LightRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

		public async Task<LightModel> CreateLightLog(LightModel light)
		{
			_dataContext.LightLog.Add(light);
			await _dataContext.SaveChangesAsync();
			return light;
		}

		public async Task<LightModel> DeleteLightLog(int logId)
		{
			LightModel foundLightModel = await _dataContext.LightLog.FirstOrDefaultAsync(x => x.Id == logId);
			if (foundLightModel != null)
			{
				_dataContext.LightLog.Remove(foundLightModel);
				await _dataContext.SaveChangesAsync();
			}
			return foundLightModel;
		}

		public async Task<List<LightModel>> GetAllLightLogs()
		{
			return await _dataContext.LightLog.ToListAsync();
		}

		public async Task<LightModel> GetLevelOfLight()
		{
			return await _dataContext.LightLog.OrderByDescending(x => x.TimeOfLog).FirstAsync();
			
		}

		public async Task<List<LightModel>> GetLightLogByTime(DateTime startTime, DateTime endTime)
		{
			return await _dataContext.LightLog.Where(x => x.TimeOfLog > startTime && x.TimeOfLog < endTime).ToListAsync();
		}

		public Task<LightModel> SetLevelOfLight(LightModel light)
		{
			throw new NotImplementedException();
		}

		public async Task<LightModel> UpdateLightLog(LightModel logEntry, int logId)
		{
			LightModel updateLog = await _dataContext.LightLog.FirstOrDefaultAsync(x => x.Id == logId);
			if (updateLog is not null) {
				updateLog.LevelOfLight = logEntry.LevelOfLight;
				updateLog.TimeOfLog= logEntry.TimeOfLog;
				updateLog.LightLevelInStable = logEntry.LightLevelInStable;
				await _dataContext.SaveChangesAsync();
			}
			return updateLog;
		}

		public async Task<LightModel> UpdateLightStatus(LightModel light)
		{
			LightModel newestLog = await _dataContext.LightLog.OrderByDescending(x => x.TimeOfLog).FirstAsync();
			if (newestLog is not null) {
				newestLog.LevelOfLight = light.LevelOfLight;
				newestLog.TimeOfLog= light.TimeOfLog;
				newestLog.LightLevelInStable = light.LightLevelInStable;
				await _dataContext.SaveChangesAsync();
			}
			return newestLog;
		}

		//this is my connection string
		//string conectionString = _dataContex.OnConfiguration;
		//"Host=localhost;Username=postgres;Password=1505;Database=ThePigFarm";


	}
}
