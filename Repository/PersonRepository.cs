using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using person_api.Model;
using System.Linq;
using person_api.Data;

namespace person_api.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDatabaseConnection _databaseConnection;

        public PersonRepository(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public async Task<Person> GetById(int id)
        {
            string query = "SELECT * FROM Person WHERE PersonId = @Id";
            SqlConnection connection = _databaseConnection.OpenDatabaseConnection();
            var result = await connection.QuerySingleOrDefaultAsync<Person>(sql: query, new { Id = id });
            return result;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            string query = "SELECT * FROM Person";
            SqlConnection connection = _databaseConnection.OpenDatabaseConnection();
            var result = await connection.QueryAsync<Person>(sql: query);
            return result.ToList();
        }

        public async Task<int> Add(Person person)
        {
            var query = "INSERT INTO Person (Name, Age) VALUES (@Name, @Age)";
            SqlConnection connection = _databaseConnection.OpenDatabaseConnection();
            var numberOfAffectedLines = await connection.ExecuteAsync(sql: query, param: person);
            return numberOfAffectedLines;
        }

        public async Task<int> Update(Person person)
        {
            string query = "UPDATE Person SET Name = @Name, Age = @Age WHERE PersonId = @PersonId";
            SqlConnection connection = _databaseConnection.OpenDatabaseConnection();
            int numberOfAffectedLines = await connection.ExecuteAsync(sql: query, param: person);
            return numberOfAffectedLines;
        }

        public async Task<int> Delete(int id)
        {
            string query = "DELETE FROM Person WHERE PersonId = @id";
            SqlConnection connection = _databaseConnection.OpenDatabaseConnection();
            int numberOfAffectedLines = await connection.ExecuteAsync(sql: query, new { id });
            return numberOfAffectedLines;
        }
    }
}