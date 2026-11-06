using System;

namespace IJ_Rasp_OnlineStore
{
    internal class Shop
    {
        private IStock _stock;

        public Shop(IStock stock)
        {
            if (stock == null)
                throw new ArgumentNullException(nameof(stock));

            _stock = stock;
        }

        public Cart Cart()
        {
            return new Cart(_stock);
        }
    }
}
