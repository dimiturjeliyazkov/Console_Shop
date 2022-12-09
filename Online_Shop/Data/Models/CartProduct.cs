using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Data.Models
{
    class CartProduct:Product
    {
        public string Id { get; set; }

        private int weightInGr;

        public int WeightInGr
        {
            get { return weightInGr; }
            set { weightInGr = value; }
        }
        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

    }
}
