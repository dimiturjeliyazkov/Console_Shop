using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Data
{
    class Drink:Product
    {
        [Key]
        public string Id { get; set; }


        private int weightInMl;

        public int WeightInMl
        {
            get { return weightInMl; }
            set { weightInMl = value; }
        }
    }
}
