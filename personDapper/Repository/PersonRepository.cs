using Dapper;
using Microsoft.Extensions.Configuration;
using personDapper.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace personDapper.Repository
{

    public class PersonRepository : IPersonRepository
    {
        private readonly IDbConnection _dbConnection;

        public PersonRepository(IConfiguration configuration)
        {
            _dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public IEnumerable<Person> GetAll()
        {
            return _dbConnection.Query<Person>("SELECT * FROM Persons");
        }

        public Person GetById(int id)
        {
            return _dbConnection.QueryFirstOrDefault<Person>("SELECT * FROM Persons WHERE id = @id", new { id=id });
        }

        public void Insert(Person person)
        {
            _dbConnection.Execute("INSERT INTO Persons (FirstName, LastName, Departmant) VALUES (@FirstName, @LastName, @Departmant)", person);
        }

        public void Update(Person person)
        {
            _dbConnection.Execute("UPDATE Persons SET FirstName = @FirstName, LastName = @LastName, Departmant = @Departmant WHERE id = @id", person);
        }

        public void Delete(int id)
        {
            _dbConnection.Execute("DELETE FROM Persons WHERE id = @id", new { id = id });
        }
    }

}
