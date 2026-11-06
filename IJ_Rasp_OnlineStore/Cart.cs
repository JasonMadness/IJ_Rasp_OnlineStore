using System;
using System.Collections.Generic;

namespace IJ_Rasp_OnlineStore
{
    internal class Cart
    {
        private IStock _stock;
        private Dictionary<Good, int> _items;

        public Cart(IStock stock)
        {
            if (stock == null)
                throw new ArgumentNullException(nameof(stock));

            _stock = stock;
            _items = new Dictionary<Good, int>();
        }

        public void Add(Good good, int quantity)
        {
            _stock.EnsureAvailable(good, quantity);

            if (_items.ContainsKey(good))
                _items[good] += quantity;
            else
                _items[good] = quantity;
        }

        public Order Order()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("The cart is empty.");

            foreach (KeyValuePair<Good, int> item in _items)
                _stock.TakeFromStock(item.Key, item.Value);

            _items.Clear();
            return new Order();
        }

        public void ShowGoods()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("The cart is empty.");
                return;
            }

            Console.WriteLine("Current goods in the cart:");

            foreach (var item in _items)
                Console.WriteLine($"{item.Key.Name}: {item.Value}");
        }
    }
}
