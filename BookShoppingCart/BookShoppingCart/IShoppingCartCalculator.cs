using System.Collections.Generic;

namespace BookShoppingCart
{
    public interface IShoppingCartCalculator
    {
        decimal Calculate(IEnumerable<Book> books);
    }
}