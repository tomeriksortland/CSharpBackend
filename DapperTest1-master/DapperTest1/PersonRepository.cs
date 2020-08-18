using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DapperTest1
{
    public class PersonRepository
    {
        private SqlConnection _connection;

        public PersonRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> Create(Person person)
        {
            return int rowsInserted1 = await conn.ExecuteAsync(create, new { FirstName = "Terje", LastName = "Kolderup", BirthYear = 1975 });
        }
    }
}
