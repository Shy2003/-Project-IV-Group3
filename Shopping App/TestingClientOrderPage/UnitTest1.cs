using System;
using System.Net.Sockets;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Client_PC01;

namespace TestingClientOrderPage
{
    [TestClass]
    public class OrderPageFormTests
    {
        [TestMethod]
        public void AdjustQuantity_Test()
        {
            // Arrange
            OrderPageForm orderForm = new OrderPageForm();
            int expectedQuantity = 2;

            // Act
            orderForm.numericUpDown1.Value = expectedQuantity;

            // Assert
            Assert.AreEqual(expectedQuantity, orderForm.numericUpDown1.Value);
        }

        [TestMethod]
        public void CalculateTotalPrice_Test()
        {
            // Arrange
            OrderPageForm orderForm = new OrderPageForm();
            int expectedTotalPrice = 24; // Assuming Espresso costs $12

            // Act
            orderForm.numericUpDown1.Value = 2; // Quantity
            int totalPrice = orderForm.GetPrice(orderForm.numericUpDown1) * (int)orderForm.numericUpDown1.Value;

            // Assert
            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }

        [TestMethod]
        public void ItemSelection_Test()
        {
            // Arrange
            OrderPageForm orderForm = new OrderPageForm();
            string expectedItem = "Espresso";

            // Act
            orderForm.numericUpDown1.Value = 1; // Quantity

            // Assert
            Assert.IsFalse(orderForm.orderDetailsListBox.Items.Contains(expectedItem));
        }
    }
}
