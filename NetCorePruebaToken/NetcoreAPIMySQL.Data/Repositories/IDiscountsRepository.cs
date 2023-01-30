using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreAPIMySQL.Model;

namespace NetcoreAPIMySQL.Data.Repositories
{
    public interface IDiscountsRepository
    {
      
        Task<IEnumerable<Discounts>> GetDiscounts();

        Task<Discounts> GetDiscountsDetails(int id);

        Task<bool> InsertDiscounts(Discounts discounts);

        Task<string> UpdateDiscounts(Discounts discounts);

        Task<string> DeleteDiscounts(Discounts discounts);

    }
}
