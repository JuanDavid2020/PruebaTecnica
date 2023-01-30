using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace NetcoreAPIMySQL.Data.Repositories
{
    public class SalesRepository : ISalesRepository
    {

        private MySQLConfiguration _connectionString;

        public SalesRepository(MySQLConfiguration connectionString)

        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<string> DeleteSales(Sales Sales)
        {
            string response = " ";
            var db = dbConection();
            var sql = @"
                      DELETE
                      FROM sales
                      WHERE  IdSales=@Id";

            var result = await db.ExecuteAsync(sql, new { Id =Sales.IdSales });
            if (result != 0)
            {

                response = "Registro elimindado";
                return response;
            }
            response = "Registro No encontrado";
            return response;
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Sales>> GetSales()
        {

            var db = dbConection();
            var sql = @"SELECT IdSales,DescriptionSale,SaleValue,QuantityProducts,SaleDate,DiscountSale
                    FROM sales";

            return await db.QueryAsync<Sales>(sql, new { });
            throw new NotImplementedException();
        }

        public async Task<Sales> GetSalesDetails(int id)
        {

            var db = dbConection();
            var sql = @"SELECT IdSales,DescriptionSale,SaleValue,QuantityProducts,SaleDate,DiscountSale
                    FROM sales WHERE idSales=@Id";
            return await db.QueryFirstOrDefaultAsync<Sales>(sql, new { Id = id });
            throw new NotImplementedException();
        }

        public  async Task<IEnumerable<object>> InsertSales(int QuantityProducts, string DescriptionSale)
        {
            float SaleValue = 0;
            string DiscountSale = "N";
            string SaleDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var db = dbConection();

            var sql = @"SELECT * 
                       FROM discounts WHERE Console=@DescriptionSale";
            var result = await db.QueryFirstOrDefaultAsync<Discounts>(sql,new{ DescriptionSale = DescriptionSale });

            if (QuantityProducts > 1)
            {
                SaleValue = result.MinimalPrice * (float)((100 - result.Discount) / 100) * QuantityProducts;
                DiscountSale = "S";
            }
            else
            {
                SaleValue = result.MinimalPrice;
                DiscountSale = "N";
            }

            sql = @"INSERT INTO sales(DescriptionSale,SaleValue,QuantityProducts,SaleDate,DiscountSale)
                      VALUES(@DescriptionSale,@SaleValue,@QuantityProducts,@SaleDate,@DiscountSale)";
            var result1 = await db.ExecuteAsync(sql, new { DescriptionSale, SaleValue, QuantityProducts, SaleDate, DiscountSale });

            sql = @"SELECT SaleValue as ValorCobrarCliente 
                             FROM sales 
                             order by SaleDate desc 
                             LIMIT 1;";
            if (result1 > 0)
            {
                return await db.QueryAsync<object>(sql, new { });

            }
            else
            {
                return await db.QueryAsync<object>(sql, new { });
            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<object>> SumSales(string type)
        {

            var db = dbConection();

            if(type == "T")
             {
                var sql = @"SELECT sum(SaleValue) as Valor_Total_Sales
                        FROM sales";
                return await db.QueryAsync<object>(sql, new { });
            }
            if (type == "S")
            {
                var sql = @"SELECT sum(SaleValue) as Valor_Total_Sales_Con_Descuento
                        FROM sales
                        WHERE DiscountSale=@type";
                return await db.QueryAsync<object>(sql, new {type});
            }
            if (type == "N")
            {
                var sql = @"SELECT sum(SaleValue) as Valor_Total_Sales_Sin_Descuento
                        FROM sales
                        WHERE DiscountSale=@type";
                return await db.QueryAsync<object>(sql, new { type});
            }

            throw new NotImplementedException();
        }



        public  async Task<string> UpdateSales(Sales sales)
        {

            string response = " ";
            if (sales!= null)
            {

                var db = dbConection();
                var sql = @"SELECT IdSales,DescriptionSale,SaleValue,QuantityProducts,SaleDate,DiscountSale
                    FROM sales WHERE idSales=@Id";
                var result = db.QueryAsync<Sales>(sql, new { Id = sales.IdSales });

                if (result.Result.ToArray<Sales>().Length != 0)
                {

                     sql = @"
                      UPDATE sales
                                SET DescriptionSale=@DescriptionSale,SaleValue=@SaleValue,QuantityProducts=@QuantityProducts,SaleDate=@SaleDate,DiscountSale=@DiscountSale
                      WHERE IdSales=@Id";
                    var result1 = await db.ExecuteAsync(sql, new { sales.DescriptionSale, sales.SaleValue, sales.SaleDate, sales.DiscountSale, result.Result.ToArray<Sales>()[0].IdSales });
                    if (result1 != 0)
                    {

                        response = "Venta Actualizada";
                        return response;
                    }
                    response = "Venta No Valida";
                    return response;
                }
            }
            response = "Venta No Encontrada";
            return response;
            throw new NotImplementedException();
        }

    }
}
