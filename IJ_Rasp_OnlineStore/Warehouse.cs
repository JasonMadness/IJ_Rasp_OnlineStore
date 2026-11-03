using System;
using System.Collections.Generic;

namespace IJ_Rasp_OnlineStore
{
    internal class Warehouse
    {
        private Dictionary<string, int> _inventory;

        public Warehouse()
        {
            _inventory = new Dictionary<string, int>();
        }

        public void Deliver(Good good, int quantity)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be a positive integer.", nameof(quantity));

            if (_inventory.ContainsKey(good.Name))
                _inventory[good.Name] += quantity;
            else
                _inventory[good.Name] = quantity;
        }

        public Dictionary<string, int> GetStock(Good good, int quantity)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be a positive integer.", nameof(quantity));

            if (_inventory.ContainsKey(good.Name) == false)
                Console.WriteLine($"The product '{good.Name}' is not available in the warehouse.");

            if (_inventory[good.Name] < quantity)
                Console.WriteLine($"Insufficient stock for '{good.Name}'. Available: {_inventory[good.Name]}, Requested: {quantity}.");

            _inventory[good.Name] -= quantity;
            return new Dictionary<string, int> { { good.Name, quantity } };
        }
    }
}
