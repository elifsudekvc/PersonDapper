using Dapper;
using Microsoft.Extensions.Configuration;
using personDapper.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace personDapper.Repository
{
    public class VKIRepository : IVKIRepository
    {
        private readonly IDbConnection _dbConnection;
    
        public VKIRepository(IConfiguration configuration)
        {
            _dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public List<VKI> GetAll(string que, object parametres = null)
        {
            return _dbConnection.Query<VKI>("SELECT * FROM VKI"+que,parametres).ToList();
        }

        public VKI GetById(string que, object parametres = null)
        {
            return _dbConnection.QueryFirstOrDefault<VKI>("SELECT * FROM VKI " + que, parametres);
        }

        public void Insert(VKI vki)
        {
            
              _dbConnection.Execute("INSERT INTO VKI (kilo, boy, vkiSonuc) VALUES (@kilo, @boy, @vkiSonuc)", vki);

        }

        public void Delete(string que, object parametres = null)
        {
            _dbConnection.Execute("DELETE FROM VKI"+que,parametres);
        }
    }

}
