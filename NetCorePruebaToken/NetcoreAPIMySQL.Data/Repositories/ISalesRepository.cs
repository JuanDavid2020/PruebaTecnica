
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreAPIMySQL.Model;


namespace NetcoreAPIMySQL.Data.Repositories
{
    public interface ISalesRepository
    {
        Task<IEnumerable<Sales>> GetSales();

        Task<Sales> GetSalesDetails(int id);

        Task<IEnumerable<object>> InsertSales(int QuantityProducts, string DescriptionSale);

        Task<IEnumerable<object>> SumSales(string type);

        Task<string> UpdateSales(Sales sales);

        Task<string> DeleteSales(Sales sales);

    }
}
