using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Products
{
    public class Product
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public static Product Parse(string[] array)
        {
            return new Product()
            {
                Type = array[1],

                Name = array[0],

                Price = double.Parse(array[2]),

                Quantity = int.Parse(array[3])
            };
        }
    }
}
