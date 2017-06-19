using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShoppingCart
{
    public class ShoppingCartCalculator : IShoppingCartCalculator
    {
        /// <summary>
        /// 計算售價
        /// </summary>
        /// <param name="books">購買的書本集合</param>
        /// <returns>售價</returns>
        public decimal Calculate(IEnumerable<Book> books)
        {
            if (books.Any() == false)
                return 0m;

            var total = 0m;
            //取得最多本的那一集,來決定套數
            var max = books.GroupBy(c => c.Id).OrderByDescending(c => c.Count()).First().Count();

            for (var i = 1; i <= max; i++)
            {
                //用GroupBy的方式取得每一套內購買的有哪幾集
                var bookSet = from book in books
                              group book by new { Id = book.Id, Name = book.Name, Price = book.Price } into g
                              //決定目前在算哪一套, Grouping後該集有N本，表示第N套以下(含)都一定會包含這一集
                              where g.Count() >= i
                              select new Book()
                              {
                                  Id = g.Key.Id,
                                  Name = g.Key.Name,
                                  Price = g.Key.Price
                              };

                total += bookSet.Sum(c => c.Price) * this.GetDiscount(bookSet.Count());
            }

            return total;
        }

        /// <summary>
        /// 依據數量決定折扣
        /// </summary>
        /// <param name="count">購買數量</param>
        /// <returns>打幾折</returns>
        private decimal GetDiscount(int count)
        {
            if (count >= 5)
                return 0.75m;

            if (count >= 4)
                return 0.8m;

            if (count >= 3)
                return 0.9m;

            if (count >= 2)
                return 0.95m;

            return 1m;
        }
    }
}
