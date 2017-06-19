using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShoppingCart
{
    public class ShoppingCartCalculator : IShoppingCartCalculator
    {
        public decimal Calculate(IEnumerable<Book> books)
        {
            var sum = books.Sum(c => c.Price);

            return sum;
        }
    }
}
