using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class Sales
    {

        public int IdSales { get; set; }

        public string DescriptionSale { get; set; }

        public float SaleValue { get; set; }

        public float QuantityProducts { get; set; }
        
        public DateTime SaleDate { get; set; }

        public  string DiscountSale { get;set; }
    }
}
