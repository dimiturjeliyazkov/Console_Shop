using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Data
{
    class Food:Product
    {
        [Key]
        public string Id { get; set; }
        private int weightInGr;

        public int WeightInGr
        {
            get { return weightInGr; }
            set { weightInGr = value; }
        }
    }
}
