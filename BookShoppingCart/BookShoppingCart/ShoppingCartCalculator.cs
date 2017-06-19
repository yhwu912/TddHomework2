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
            var sum = books.Sum(c => c.Price) * GetDiscount(books.Count());

            return sum;
        }

        private decimal GetDiscount(int count)
        {
            if (count >= 2)
                return 0.95m;
            else
                return 1m;            
        }
    }
}
