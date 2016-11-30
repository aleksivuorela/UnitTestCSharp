using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCSharp
{
    public class Basket
    {
        public string Customer { get; set; }
        public List<string> Contents { get; set; }
        public float Price { get; set; }

        public Basket(string customer, List<string> contents, float price)
        {
            Customer = customer;
            Contents = contents;
            Price = price;
        }

        public void AddProduct(string product, float price)
        {
            Contents.Add(product);
            Price += price;
        }

        public void DeleteProduct(string product, float price)
        {
            foreach (string s in Contents.ToList())
            { 
                if (s == product)
                {
                    Contents.Remove(s);
                    Price -= price;
                }
            }
        }

        public float CountDiscountPrice(float percent)
        {
            float discount = percent / 100.0f;
            return Price - Price * discount;
        }

        public int CountProducts()
        {
            return Contents.Count;
        }

        public float AddShippingFee(float fee)
        {
            return Price + fee;
        }

        public void ClearContents()
        {
            Contents.Clear();
        }

        public int CountSameProducts(string productName)
        {
            int sameProductsCount = 0;
            foreach (string product in Contents)
            {
                if (product == productName)
                    sameProductsCount++;
            }
            return sameProductsCount;
        }
    }
}
