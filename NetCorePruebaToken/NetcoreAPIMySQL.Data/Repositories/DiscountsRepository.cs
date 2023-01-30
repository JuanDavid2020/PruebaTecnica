using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;


namespace NetcoreAPIMySQL.Data.Repositories
{
    public class DiscountsRepository : IDiscountsRepository
    {

        private MySQLConfiguration _connectionString;

        public DiscountsRepository(MySQLConfiguration connectionString)

        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Discounts>> GetDiscounts()
        {

            var db = dbConection();
            var sql = @"SELECT id,Console,MinimalPrice,MaximumPrice,Discount
                    FROM discounts";
            return await db.QueryAsync<Discounts>(sql,new { });
            throw new NotImplementedException();
        }

        public async Task<Discounts> GetDiscountsDetails(int id)
        {

            var db = dbConection();
            var sql = @"SELECT id,Console,MinimalPrice,MaximumPrice,Discount
                    FROM discounts WHERE id=@Id";
            return await db.QueryFirstOrDefaultAsync<Discounts>(sql, new {Id=id});
            throw new NotImplementedException();
        }

        public async Task<bool> InsertDiscounts(Discounts discounts)
        {
            var db = dbConection();
            var sql = @"
                      INSERT INTO discounts(Console,MinimalPrice,MaximumPrice,Discount)
                      VALUES(@Console,@MinimalPrice,@MaximumPrice,@Discount)";

            var result= await db.ExecuteAsync(sql, new {discounts.Console,discounts.MinimalPrice,discounts.MaximumPrice,discounts.Discount});

            return result > 0;
            throw new NotImplementedException();
        }

        public  async Task<string> UpdateDiscounts(Discounts discounts)
        {
            string response = " ";
            if (discounts != null)
            {

                var db = dbConection();

                var sql = @"SELECT id,Console,MinimalPrice,MaximumPrice,Discount
                    FROM discounts WHERE Console=@Console";
                var result = db.QueryAsync<Discounts>(sql, new { Console = discounts.Console });
                if (result.Result.ToArray<Discounts>().Length != 0)
                {

                     sql = @"
                      UPDATE discounts
                                SET Console=@Console,MinimalPrice=@MinimalPrice,MaximumPrice=@MaximumPrice,Discount=@Discount
                      WHERE id=@Id";

                    var result1 = await db.ExecuteAsync(sql, new { discounts.Console, discounts.MinimalPrice, discounts.MaximumPrice, discounts.Discount, result.Result.ToArray<Discounts>()[0].Id });
                    if (result1 != 0)
                    {

                        response = "Registro Actualizado";
                        return response;
                    }
                    response = "Registro No Valido";
                    return response;
                }
            }

            response = "Registro No Encontrado";
            return response;
            throw new NotImplementedException();
        }

        public async Task<string> DeleteDiscounts(Discounts discounts)
        {
            string response = " ";
            var db = dbConection();
            var sql = @"
                      DELETE
                      FROM discounts
                      WHERE id=@Id";

            var result = await db.ExecuteAsync(sql, new {Id=discounts.Id});
            if (result != 0)
            {

                response = "Registro elimindado";
                return response;
            }

            response = "Registro No encontrado";
            return response;

            throw new NotImplementedException();
        }
    }
}
