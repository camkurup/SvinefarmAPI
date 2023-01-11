using Npgsql;
using SvinefarmAPI.Interfaces;
using SvinefarmAPI.Model;

namespace SvinefarmAPI.Repository
{
    public class TemperatureRepository : ITemperature
    {
        ThePigFarmContext _thePigFarmContext;

        public TemperatureRepository(ThePigFarmContext thePigFarmContext)
        {
            _thePigFarmContext = thePigFarmContext;
        }

        public TemperatureRepository()
        {
        }

        //this is my connection string
        string conectionString = "Host=localhost;Username=postgres;Password=1505;Database=ThePigFarm";

        public TemperatureModel GetCurrentTemperature()
        {

            //This opens for the connection to my DB
            NpgsqlConnection con = new NpgsqlConnection(conectionString);
            con.Open();

            DateTime currentTime = DateTime.Now;

            //this is a new command object this makes sure that the query can be executed
            string query = "SELECT * FROM TEMPERATURELOG WHERE Id = 1";

            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

            cmd.Parameters.AddWithValue("@currentTime", currentTime);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            TemperatureModel temperature = new TemperatureModel();
            while (reader.Read())
            {
                temperature.Id = Convert.ToInt32(reader[("Id")]);
                temperature.Temperature = Convert.ToInt32(reader[("Temperature")]);
                temperature.TimeOfLog = Convert.ToDateTime(reader[("TimeOfLog")]);
                temperature.UVLightOn = Convert.ToBoolean(reader[("LightOn")]);
            }
            //This closes my connection
            con.Close();

            return temperature;
        }

        public Lightlog GetLight()
        {

            //This opens for the connection to my DB
            NpgsqlConnection con = new NpgsqlConnection(conectionString);
            con.Open();

            DateTime currentTime = DateTime.Now;

            //this is a new command object this makes sure that the query can be executed
            string query = "SELECT * FROM LightLog WHERE Id = 2";

            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

            cmd.Parameters.AddWithValue("@currentTime", currentTime);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            Lightlog Light = new Lightlog();
            while (reader.Read())
            {
                Light.Id = Convert.ToInt32(reader[("Id")]);
                Light.Leveloflight = Convert.ToInt32(reader[("LevelOfLight")]);
                Light.Timeoflog = Convert.ToDateTime(reader[("TimeOfLog")]);
                Light.Lightlevelinstable = Convert.ToInt32(reader[("LightLevelInStable")]);
            }
            //This closes my connection
            con.Close();

            return Light;
        }

        int ITemperature.GetCurrentTemperature()
        {
            throw new NotImplementedException();
        }
    }
}
