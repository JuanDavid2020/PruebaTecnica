using Dapper;
using MySql.Data.MySqlClient;
using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetcoreAPIMySQL.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {


        private MySQLConfiguration _connectionString;

        public UsersRepository(MySQLConfiguration connectionString)

        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<Users> GetUsers(string User, string Password)
        {

            var db = dbConection();
            var sql = @"SELECT User,Password
                    FROM users WHERE User=@User
                    AND Password=@Password";
            return await db.QueryFirstOrDefaultAsync<Users>(sql, new { User,Password });
            throw new NotImplementedException();
        }
    }
}
