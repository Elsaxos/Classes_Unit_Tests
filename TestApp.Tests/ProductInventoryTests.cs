using NUnit.Framework;

using TestApp.Product;

using NUnit.Framework;
using TestApp.Product;

namespace TestApp.Tests
{
    [TestFixture]
    public class ProductInventoryTests
    {
        private ProductInventory _inventory = null!;

        [SetUp]
        public void SetUp()
        {
            this._inventory = new ProductInventory();
        }

        [Test]
        public void Test_AddProduct_ProductAddedToInventory()
        {
            // Arrange
            string productName = "Laptop";
            double productPrice = 999.99;
            int productQuantity = 5;

            // Act
            this._inventory.AddProduct(productName, productPrice, productQuantity);

            // Assert
            Assert.AreEqual(1, this._inventory.DisplayInventory().Split('\n').Length - 1);
        }

        [Test]
        public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
        {
            // Act
            string result = this._inventory.DisplayInventory();

            // Assert
            Assert.AreEqual("Product Inventory:", result.Trim());
        }

        [Test]
        public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
        {
            // Arrange
            this._inventory.AddProduct("Laptop", 999.99, 5);
            this._inventory.AddProduct("Phone", 499.99, 10);

            // Act
            string result = this._inventory.DisplayInventory();

            // Assert
            StringAssert.Contains("Laptop - Price: $999.99 - Quantity: 5", result.Replace(',', '.'));
            StringAssert.Contains("Phone - Price: $499.99 - Quantity: 10", result.Replace(',', '.'));
        }


        [Test]
        public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
        {
            // Act
            double result = this._inventory.CalculateTotalValue();

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
        {
            // Arrange
            this._inventory.AddProduct("Laptop", 999.99, 5);
            this._inventory.AddProduct("Phone", 499.99, 10);

            // Act
            double result = this._inventory.CalculateTotalValue();

            // Assert
            Assert.AreEqual(999.99 * 5 + 499.99 * 10, result);
        }
    }
}
