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

        public int GetAvailable(Good good)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (_inventory.ContainsKey(good.Name))
                return _inventory[good.Name];

            return 0;
        }

        public void EnsureAvailable(Good good, int quantity)
        {
            ValidateRequest(good, quantity);
        }

        public void TakeFromStock(Good good, int quantity)
        {
            ValidateRequest(good, quantity);

            _inventory[good.Name] -= quantity;
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

        private void ValidateRequest(Good good, int quantity)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be a positive integer.", nameof(quantity));

            int available = GetAvailable(good);

            if (available < quantity)
                throw new InvalidOperationException($"Insufficient stock for '{good.Name}'. Available: {available}, requested: {quantity}.");
        }
    }
}