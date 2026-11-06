using System;

namespace IJ_Rasp_OnlineStore
{
    internal class Shop
    {
        private Cart _cart;

        public Shop(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            _cart = new Cart(warehouse);
        }

        public Cart Cart()
        {
            return _cart;
        }
    }
}
