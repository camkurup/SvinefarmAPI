using Npgsql;
using SvinefarmAPI.Helpers;
using SvinefarmAPI.Interfaces;
using SvinefarmAPI.Model;

namespace SvinefarmAPI.Repository
{
    public class LightRepository
    {
        ILight _light;
        DataContext _dataContext;

        public LightRepository(ILight light, DataContext dataContext)
        {
            _light = light;
            _dataContext = dataContext;
        }

        //this is my connection string
        //string conectionString = _dataContex.OnConfiguration;
            //"Host=localhost;Username=postgres;Password=1505;Database=ThePigFarm";

        public LightModel GetLevelOfLight()
        {

            NpgsqlConnection con = new NpgsqlConnection(conectionString);
            con.Open();

            DateTime currentTime = DateTime.Now;

            string query = "SELECT * FROM LIGHTLOG WHERE TimeOfLog = @currentTime";

            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

            cmd.Parameters.AddWithValue("@currentTime", currentTime);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            LightModel lightLevel = new LightModel();


            while (reader.Read())
            {
                lightLevel.Id = Convert.ToInt32(reader[("Id")]);
                lightLevel.LevelOfLight = Convert.ToInt32(reader[("LevelOfLight")]);
                lightLevel.TimeOfLog = Convert.ToDateTime(reader[("TimeOfLog")]);
                lightLevel.LightLevelInStable = Convert.ToInt32(reader[("LightLevelInStable")]);
            }

            con.Close();

            return lightLevel;
        }
    }
}
