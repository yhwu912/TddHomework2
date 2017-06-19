using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShoppingCart.Tests
{
    [TestClass()]
    public class ShoppingCartCalculatorTests
    {
        [TestMethod()]
        public void 第一集買了一本_其他都沒買_價格應為100元()
        {
            //Arrage
            var books = new List<Book>
            {
                new Book { Id = Guid.NewGuid(), Name = "哈利波特第一集", Price = 100 }
            };

            //Act
            var actual = new ShoppingCartCalculator().Calculate(books);
            decimal expected = 100;

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void 第一集買了一本_第二集也買了一本_價格應為190元()
        {
            //Arrage
            var books = new List<Book>
            {
                new Book { Id = Guid.NewGuid(), Name = "哈利波特第一集", Price = 100 },
                new Book { Id = Guid.NewGuid(), Name = "哈利波特第二集", Price = 100 }
            };

            //Act
            var actual = new ShoppingCartCalculator().Calculate(books);
            decimal expected = 190;

            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}