using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr12._11._2022
{
    public class Medications
    {
       

        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool Recipe { get; set; }

       
        public Medications(string name, int quantity, double price, bool recipe)
        {
               Name = name;
            Quantity = quantity;
            Price = price;
            Recipe = recipe;
        }
        public Medications()
        {
        }
    }





}
