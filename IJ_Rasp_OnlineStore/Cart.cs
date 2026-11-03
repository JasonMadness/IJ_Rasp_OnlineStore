using System;
using System.Collections.Generic;

namespace IJ_Rasp_OnlineStore
{
    internal class Cart
    {
        private Dictionary<string, int> _items;

        public Cart()
        {
            _items = new Dictionary<string, int>();
        }

        public void AddGoods(Good good, int quantity)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be a positive integer.", nameof(quantity));

            if (_items.ContainsKey(good.Name))
                _items[good.Name] += quantity;
            else
                _items[good.Name] = quantity;
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
