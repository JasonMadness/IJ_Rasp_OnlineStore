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

        public void AddGoods(Warehouse warehouse, Good good, int quantity)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be a positive integer.", nameof(quantity));

            if (warehouse.GetStock(good, quantity).ContainsKey(good.Name))
                _items[good.Name] += quantity;
            else
                _items[good.Name] = quantity;
        }
    }
}
