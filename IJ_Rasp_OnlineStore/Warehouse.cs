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

        public Dictionary<string, int> TakeFromStock(Good good, int quantity)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be a positive integer.", nameof(quantity));

            if (_inventory.TryGetValue(good.Name, out int available) == false || available < quantity)
                throw new InvalidOperationException($"Insufficient stock for '{good.Name}'. Available: {available}, requested: {quantity}.");

            _inventory[good.Name] -= quantity;
            return new Dictionary<string, int> { { good.Name, quantity } };
        }

        public void ShowStock()
        {
            if (_inventory.Count == 0)
            {
                Console.WriteLine("The warehouse is empty.");
                return;
            }

            Console.WriteLine("Current stock in the warehouse:");

            foreach (var item in _inventory)
                Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
