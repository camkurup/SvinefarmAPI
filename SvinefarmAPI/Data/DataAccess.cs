using Npgsql;
using SvinefarmAPI.Model;

namespace SvinefarmAPI.Data
{
    /// <summary>
    /// I keept this class because my intention is to get the connection string from here to all other classes. 
    /// I just dont remember how at this moment and do not want to be stuck on this
    /// </summary>
    public class DataAccess
    {
        public string ConnectionString { get; set; }

        public DataAccess(string connectionString)
        {
            ConnectionString = "Host=localhost;Username=postgres;Password=1505;Database=ThePigFarm";
        }

        //this is my connection string
        //string conectionString = "Host=localhost;Username=postgres;Password=1505;Database=ThePigFarm";

    }
}
