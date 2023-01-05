using Npgsql;
using SvinefarmAPI.Model;

namespace SvinefarmAPI.Data
{
    public class LightRepository
    {
        //DataAccess dataAccess = new DataAccess("");

        //this is my connection string
        string conectionString = "Host=localhost;Username=postgres;Password=1505;Database=ThePigFarm";

        /// <summary>
        /// This Methode is not satisfying. But works allright as a placeholder
        /// Makesure to come back an correct this
        /// </summary>
        /// <returns></returns>
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
