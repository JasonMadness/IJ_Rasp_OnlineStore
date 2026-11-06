using System;
using System.Collections.Generic;

namespace IJ_Rasp_OnlineStore
{
    internal class Cart
    {
        private Warehouse _warehouse;
        private Dictionary<string, int> _items;

        public Cart(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            _warehouse = warehouse;
            _items = new Dictionary<string, int>();
        }

        public void Add(Good good, int quantity)
        {
            _warehouse.EnsureAvailable(good, quantity);

            if (_items.ContainsKey(good.Name))
                _items[good.Name] += quantity;
            else
                _items[good.Name] = quantity;
        }

        public Order Order()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("The cart is empty.");

            foreach (KeyValuePair<string, int> item in _items)
                _warehouse.TakeFromStock(new Good(item.Key), item.Value);

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
                Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
