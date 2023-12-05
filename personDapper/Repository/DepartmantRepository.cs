using Dapper;
using Microsoft.Extensions.Configuration;
using personDapper.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace personDapper.Repository
{
    public class DepartmantRepository : IDepartmantRepository
    {
        private readonly IDbConnection _dbConnection;

        public DepartmantRepository(IConfiguration configuration)
        {
            _dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public IEnumerable<Departmant> GetAll()
        {
            return _dbConnection.Query<Departmant>("SELECT * FROM Departmants");
        }

        public Departmant GetById(int DepartmantId)
        {
            return _dbConnection.QueryFirstOrDefault<Departmant>("SELECT * FROM Departmants WHERE DepartmantId = @DepartmantId", new { DepartmantId = DepartmantId });
        }

        public void Insert(Departmant departmant)
        {
            _dbConnection.Execute("INSERT INTO Departmants (DepartmantName) VALUES (@DepartmantName)", departmant);
        }

        public void Update(Departmant departmant)
        {
            _dbConnection.Execute("UPDATE Departmants SET DepartmantName = @DepartmantName WHERE DepartmantId = @DepartmantId", departmant);
        }

        public void Delete(int DepartmantId)
        {
            _dbConnection.Execute("DELETE FROM Departmants WHERE DepartmantId = @DepartmantId", new { DepartmantId = DepartmantId });
        }
    }

}
