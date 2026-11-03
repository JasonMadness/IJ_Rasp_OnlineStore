using System;
using System.Collections.Generic;

namespace IJ_Rasp_OnlineStore
{
    internal class Shop
    {
        private Warehouse _warehouse;
        private Cart _cart;

        public Shop(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            _warehouse = warehouse;
            _cart = new Cart();
        }
    }
}
