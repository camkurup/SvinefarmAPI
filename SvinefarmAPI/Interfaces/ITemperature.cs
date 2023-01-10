namespace SvinefarmAPI.Interfaces
{
    public interface ITemperatureRepository
    {
        int GetCurrentTemperature(DateTime dateTime);

    }
}
