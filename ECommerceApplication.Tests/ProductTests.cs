using NUnit.Framework;
using System;

namespace ECommerceApplication.Tests
{
    public class ProductTests
    {
        private Product _product;

        [SetUp]
        public void Setup()
        {
            _product = new Product(201, "Smartwatch", 249.99m, 100);
        }
        //sample test

        [Test]
        public void SetupVerificationTest()
        {
            Assert.Pass("Test project is correctly configured");
        }

        // 1. Test for valid product creation
        [Test]
        public void Product_Constructor_ShouldInitializeCorrectly()
        {
            Assert.That(_product.ProdID, Is.EqualTo(201));
            Assert.That(_product.ProdName, Is.EqualTo("Smartwatch"));
            Assert.That(_product.ItemPrice, Is.EqualTo(249.99m));
            Assert.That(_product.StockAmount, Is.EqualTo(100));
        }
        // 2. Test for invalid Product ID
        [Test]
        public void Product_InvalidProductID_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(2, "Gaming Console", 450m, 50));
        }

        // 3. Test for increasing stock
        [Test]
        public void IncreaseStock_ValidAmount_ShouldIncreaseStock()
        {
            _product.IncreaseStock(30);
            Assert.That(_product.StockAmount, Is.EqualTo(130));
        }

        // 4. Test for decreasing stock
        [Test]
        public void DecreaseStock_ValidAmount_ShouldDecreaseStock()
        {
            _product.DecreaseStock(25);
            Assert.That(_product.StockAmount, Is.EqualTo(75));
        }
        // 5. Test for decreasing stock below zero
        [Test]
        public void DecreaseStock_ExceedingAmount_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => _product.DecreaseStock(200));
        }

        // 6. Test for increasing stock with a negative value
        [Test]
        public void IncreaseStock_NegativeAmount_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => _product.IncreaseStock(-15));
        }
    }
}