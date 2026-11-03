using System;
using System.Collections.Generic;

namespace IJ_Rasp_OnlineStore
{
    internal class Shop
    {
        private Warehouse _warehouse;
        private Cart _cart;
        private bool _isBusy;

        public Shop(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            _warehouse = warehouse;
            _cart = new Cart();
        }

        public Cart GetCart()
        {
            if (_isBusy)
                throw new InvalidOperationException("The cart is currently busy. Please try again later.");

            _isBusy = true;
            return _cart;
        }
    }
}
