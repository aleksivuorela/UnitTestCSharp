using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestCSharp;

namespace BasketTests
{
    [TestClass]
    public class BasketTest
    {
        public Basket basket { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            List<string> products = new List<string>()
            {
                "kissa",
                "pasi"
            };
            basket = new Basket("Keijo", products, 20);
        }

        [TestCleanup]
        public void TearDown()
        {
            basket = null;
        }

        [TestMethod]
        public void TestIsCustomerString()
        {
            Assert.AreEqual(basket.Customer.GetType(), typeof(string), "variable name should be string");
        }

        [TestMethod]
        public void TestIsPriceNumber()
        {
            Assert.AreEqual(basket.Price.GetType(), typeof(float), "variable price should be a number");
        }

        [TestMethod]
        public void TestIsContentsList()
        {
            Assert.AreEqual(basket.Contents.GetType(), typeof(List<string>), "variable contents should be a list");
        }

        [TestMethod]
        public void TestAddingToList()
        {
            basket.AddProduct("kala", 1);
            CollectionAssert.Contains(basket.Contents, "kala", "add_product method did not add a product to list");
        }

        [TestMethod]
        public void TestDeleteFromList()
        {
            basket.DeleteProduct("pasi", 1);
            CollectionAssert.DoesNotContain(basket.Contents, "pasi", "delete_product method did not delete product from list");
        }

        [TestMethod]
        public void TestCountDiscount()
        {
            Assert.AreEqual(basket.CountDiscountPrice(10), 18, "count_discount_price does not count correct value");
        }

        // TypeErroria ei voi testata C#:ssa, koska kieli käyttää vahvaa tyypitystä

        // Testataan, että heittää poikkeuksen "ArgumentOutOfRangeException",
        // kun yritetään päästä käsiksi listan sadanteen alkioon (jota ei ole olemassa)
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestContentsErrorHandling()
        {
            string product = basket.Contents[100];
        }

        // Testataan, että metodi laskee ostoskorin tavaroiden lukumäärän oikein
        [TestMethod]
        public void TestCountProducts()
        {
            Assert.AreEqual(basket.CountProducts(), 2, "CountProducts does not count correct value");
        }

        // Testataan, että metodi lisää hintaan postikulut oikein
        [TestMethod]
        public void TestAddShippingFee()
        {
            Assert.AreEqual(basket.AddShippingFee(5), 25, "AddShippingFee does not add shipping fee correctly");
        }

        // Testataan, että metodi tyhjentää ostoskorin sisällön
        [TestMethod]
        public void TestClearContents()
        {
            basket.ClearContents();
            Assert.AreEqual(basket.Contents.Count, 0, "ClearContents does not remove all products");
        }

        // Testataan, että metodi laskee samojen tuotteiden lukumäärän ostoskorissa
        [TestMethod]
        public void TestCountSameProducts()
        {
            basket.AddProduct("pasi", 1);
            basket.AddProduct("pasi", 1);
            Assert.AreEqual(basket.CountSameProducts("pasi"), 3, "CountSameProducts does not count same products correctly");
        }
    }
}
