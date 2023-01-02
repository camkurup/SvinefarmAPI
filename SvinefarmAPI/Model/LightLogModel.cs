namespace SvinefarmAPI.Model
{
    public class LightLogModel
    {
        public int Id { get; set; }
        public int LevelOfLight { get; set; }
        public DateTime TimeOfLog { get; set; }
        public int LightLevelInStable { get; set; }

        public LightLogModel() { }
    }
}
