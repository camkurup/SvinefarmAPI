using Microsoft.EntityFrameworkCore;
using Npgsql;
using SvinefarmAPI.Interfaces;
using SvinefarmAPI.Model;

namespace SvinefarmAPI.Repository
{
    public class LightRepository : ILight
	{
		ThePigFarmContext _thePigFarmContext;

        public LightRepository(ThePigFarmContext thePigFarmContext)
        {
			_thePigFarmContext= thePigFarmContext;
        }

		public async Task<Lightlog> CreateLightLog(Lightlog light)
		{
            _thePigFarmContext.Lightlogs.Add(light);
			await _thePigFarmContext.SaveChangesAsync();
			return light;
		}

		public async Task<Lightlog> DeleteLightLog(int logId)
		{
            Lightlog foundLightModel = await _thePigFarmContext.Lightlogs.FirstOrDefaultAsync(x => x.Id == logId);
			if (foundLightModel != null)
			{
                _thePigFarmContext.Lightlogs.Remove(foundLightModel);
				await _thePigFarmContext.SaveChangesAsync();
			}
			return foundLightModel;
		}

		public async Task<List<Lightlog>> GetAllLightLogs()
		{
			return await _thePigFarmContext.Lightlogs.ToListAsync();
		}

		public async Task<Lightlog> GetLevelOfLight()
		{
			return await _thePigFarmContext.Lightlogs.OrderByDescending(x => x.Timeoflog).FirstAsync();
			
		}

		public async Task<List<Lightlog>> GetLightLogByTime(DateTime startTime, DateTime endTime)
		{
			return await _thePigFarmContext.Lightlogs.Where(x => x.Timeoflog > startTime && x.Timeoflog < endTime).ToListAsync();
		}

		public Task<Lightlog> SetLevelOfLight(Lightlog light)
		{
			throw new NotImplementedException();
		}

		public async Task<Lightlog> UpdateLightLog(Lightlog logEntry, int logId)
		{
            Lightlog updateLog = await _thePigFarmContext.Lightlogs.FirstOrDefaultAsync(x => x.Id == logId);
			if (updateLog is not null) {
				updateLog.Leveloflight = logEntry.Leveloflight;
				updateLog.Timeoflog= logEntry.Timeoflog;
				updateLog.Lightlevelinstable = logEntry.Lightlevelinstable;
				await _thePigFarmContext.SaveChangesAsync();
			}
			return updateLog;
		}

		public async Task<Lightlog> UpdateLightStatus(Lightlog light)
		{
            Lightlog newestLog = await _thePigFarmContext.Lightlogs.OrderByDescending(x => x.Timeoflog).FirstAsync();
			if (newestLog is not null) {
				newestLog.Leveloflight = light.Leveloflight;
				newestLog.Timeoflog = light.Timeoflog;
				newestLog.Lightlevelinstable = light.Lightlevelinstable;
				await _thePigFarmContext.SaveChangesAsync();
			}
			return newestLog;
		}
	}
}
