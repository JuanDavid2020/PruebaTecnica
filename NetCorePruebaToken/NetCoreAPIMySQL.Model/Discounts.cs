using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class Discounts
    {
        public int Id { get; set; }

        public string Console { get;set; }

        public float  MinimalPrice { get; set; }

        public float MaximumPrice { get;set;}

        public float Discount { get; set; }

    }
}
