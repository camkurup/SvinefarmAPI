using SvinefarmAPI.Model;

namespace SvinefarmAPI.Interfaces
{
    public interface ILight
	{
		Task<Lightlog> CreateLightLog(LightLogRequest light);
		Task<Lightlog> GetLevelOfLight();
		Task<List<Lightlog>> GetAllLightLogs();
		Task<Lightlog> UpdateLightLog(Lightlog logEntry, int logId);
		Task<Lightlog> UpdateLightStatus(Lightlog light);
		Task<Lightlog> DeleteLightLog(int logId);

    }
}
