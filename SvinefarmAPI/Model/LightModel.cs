namespace SvinefarmAPI.Model
{
    public class LightModel
    {
        public int Id { get; set; }
        public int LevelOfLight { get; set; }
        public DateTime TimeOfLog { get; set; }
        public int LightLevelInStable { get; set; }

        public LightModel() { }
    }
}
