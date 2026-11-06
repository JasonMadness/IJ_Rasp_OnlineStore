using System;

namespace IJ_Rasp_OnlineStore
{
    internal class Order
    {
        private string _paylink;

        public Order()
        {
            _paylink = $"https://payment.example/{Guid.NewGuid()}";
        }

        public string Paylink => _paylink;
    }
}
