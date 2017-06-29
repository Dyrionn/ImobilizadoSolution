using System.Text;
using System.Web.Configuration;

namespace ImobilizadoSolution.Infra
{
    public static class MongoDbInfra
    {
        
        public static string ServidorMongo { get; set; }
        public static string NomeBanco { get; set; }

        public static string ConnectionString()
        {
            return "mongodb://" + ServidorMongo;
        }
    }
}
