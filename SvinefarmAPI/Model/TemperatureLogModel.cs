namespace SvinefarmAPI.Model
{
    public class TemperatureLogModel
    {
        public int Id { get; set; }
        public int Temperature { get; set; }
        public DateTime TimeOfLog { get; set; }
        public bool UVLightOn { get; set; }

        public TemperatureLogModel() { }
    }
}
