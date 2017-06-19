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
        private Book _bookVolume1 = new Book { Id = Guid.NewGuid(), Name = "哈利波特第一集", Price = 100m };
        private Book _bookVolume2 = new Book { Id = Guid.NewGuid(), Name = "哈利波特第二集", Price = 100m };
        private Book _bookVolume3 = new Book { Id = Guid.NewGuid(), Name = "哈利波特第三集", Price = 100m };
        private Book _bookVolume4 = new Book { Id = Guid.NewGuid(), Name = "哈利波特第四集", Price = 100m };
        private Book _bookVolume5 = new Book { Id = Guid.NewGuid(), Name = "哈利波特第五集", Price = 100m };

        [TestMethod()]
        public void 第一集買了一本_其他都沒買_價格應為100元()
        {
            //Arrage
            var target = new ShoppingCartCalculator();
            var books = new List<Book>
            {
                _bookVolume1
            };

            //Act
            var actual = target.Calculate(books);
            var expected = 100m;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 第一集買了一本_第二集也買了一本_價格應為190元()
        {
            //Arrage
            var target = new ShoppingCartCalculator();
            var books = new List<Book>
            {
                _bookVolume1,
                _bookVolume2
            };

            //Act
            var actual = target.Calculate(books);
            var expected = 190m;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 一二三集各買了一本_價格應為270元()
        {
            //Arrage
            var target = new ShoppingCartCalculator();
            var books = new List<Book>
            {
                _bookVolume1,
                _bookVolume2,
                _bookVolume3
            };

            //Act
            var actual = target.Calculate(books);
            var expected = 270m;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 一二三四集各買了一本_價格應為320元()
        {
            //Arrage
            var target = new ShoppingCartCalculator();
            var books = new List<Book>
            {
                _bookVolume1,
                _bookVolume2,
                _bookVolume3,
                _bookVolume4
            };

            //Act
            var actual = target.Calculate(books);
            var expected = 320m;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 一次買了整套_一二三四五集各買了一本_價格應為375元()
        {
            //Arrage
            var target = new ShoppingCartCalculator();
            var books = new List<Book>
            {
                _bookVolume1,
                _bookVolume2,
                _bookVolume3,
                _bookVolume4,
                _bookVolume5
            };

            //Act
            var actual = target.Calculate(books);
            var expected = 375m;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 一二集各買了一本_第三集買了兩本_價格應為370()
        {
            //Arrage            
            var target = new ShoppingCartCalculator();
            var books = new List<Book>
            {
                _bookVolume1,
                _bookVolume2,
                _bookVolume3,
                _bookVolume3
            };

            //Act
            var actual = target.Calculate(books);
            var expected = 370m;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 第一集買了一本_第二三集各買了兩本_價格應為460()
        {
            //Arrage            
            var target = new ShoppingCartCalculator();
            var books = new List<Book>
            {
                _bookVolume1,
                _bookVolume2,
                _bookVolume2,
                _bookVolume3,
                _bookVolume3
            };

            //Act
            var actual = target.Calculate(books);
            var expected = 460m;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}