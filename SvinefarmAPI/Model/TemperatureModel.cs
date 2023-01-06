namespace SvinefarmAPI.Model
{
    public class TemperatureModel
    {
        public int Id { get; set; }
        public int Temperature { get; set; }
        public DateTime TimeOfLog { get; set; }
        public bool UVLightOn { get; set; }

        public TemperatureModel() { }
    }
}
