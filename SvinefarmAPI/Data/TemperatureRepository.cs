using Npgsql;
using SvinefarmAPI.Model;

namespace SvinefarmAPI.Data
{
    public class TemperatureRepository
    {
        //this is my connection string
        string conectionString = "Host=localhost;Username=postgres;Password=1505;Database=ThePigFarm";

        /// <summary>
        /// This Methode is not satisfying. But works allright as a placeholder
        /// Makesure to come back an correct this
        /// </summary>
        /// <returns></returns>
        public TemperatureLogModel GetCurrentTemperature()
        {

            //This opens for the connection to my DB
            NpgsqlConnection con = new NpgsqlConnection(conectionString);
            con.Open();

            DateTime currentTime = DateTime.Now;

            //this is a new command object this makes sure that the query can be executed
            string query = "SELECT * FROM TEMPERATURELOG WHERE TimeOfLog = @currentTime";

            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

            cmd.Parameters.AddWithValue("@currentTime", currentTime);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            TemperatureLogModel temperature = new TemperatureLogModel();
            while (reader.Read())
            {
                temperature.Id = Convert.ToInt32(reader[("Id")]);
                temperature.Temperature = Convert.ToInt32(reader[("Temperature")]);
                temperature.TimeOfLog = Convert.ToDateTime(reader[("TimeOfLog")]);
                temperature.UVLightOn = Convert.ToBoolean(reader[("UVLightOn")]);
            }
            //This closes my connection
            con.Close();

            return temperature;
        }

    }
}
