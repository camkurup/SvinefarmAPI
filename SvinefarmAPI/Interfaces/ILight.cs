using SvinefarmAPI.Model;

namespace SvinefarmAPI.Interfaces
{
    public interface ILightRepository
	{
		Task<LightModel> CreateLightLog(LightModel light);
		Task<LightModel> GetLevelOfLight();
		Task<List<LightModel>> GetAllLightLogs();
		Task<List<LightModel>> GetLightLogByTime(DateTime startTime, DateTime endTime);
		Task<LightModel> SetLevelOfLight(LightModel light);
		Task<LightModel> UpdateLightLog(LightModel logEntry, int logId);
		Task<LightModel> UpdateLightStatus(LightModel light);
		Task<LightModel> DeleteLightLog(int logId);

    }
}
