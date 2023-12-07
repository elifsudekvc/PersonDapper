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

        public List<Person> GetAll(string que, object parametres = null)
        {
            return _dbConnection.Query<Person>("SELECT * FROM Persons "+que,parametres).ToList();
        }

        public Person GetById(string que, object parametres=null)
        {
            return _dbConnection.QueryFirstOrDefault<Person>("SELECT * FROM Persons "+ que,parametres );
        }

        public void Insert(Person person)
        {
            _dbConnection.Execute(@"
       INSERT INTO [dbo].[Persons]
           ([FirstName]
           ,[LastName]
           ,[Departmant])
        VALUES
           (@FirstName
           ,@LastName
           ,@Departmant)", person);
        }

        public void Update(Person person)
        {
            _dbConnection.Execute(@" 
                UPDATE [dbo].[Persons]
                SET [FirstName] = @FirstName
                ,[LastName] = @LastName
                ,[Departmant] = @Departmant
                 WHERE id=@id", person);
        }

        public void Delete( string que, object parametres=null)
        {
            _dbConnection.Execute("DELETE FROM Persons "+que,parametres);
        }
    }

}
