using System;
using System.Collections.Generic;

namespace IJ_Rasp_OnlineStore
{
    internal class Order
    {
        private Dictionary<string, int> _items;
        private string _paylink;

        public Order(IReadOnlyDictionary<string, int> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            _items = new Dictionary<string, int>(items);
            _paylink = $"https://payment.example/{Guid.NewGuid()}";
        }

        public IReadOnlyDictionary<string, int> Items => _items;

        public string Paylink => _paylink;
    }
}
