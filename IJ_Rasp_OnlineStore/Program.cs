using System;

namespace IJ_Rasp_OnlineStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();
            Shop shop = new Shop(warehouse);

            warehouse.Deliver(iPhone12, 10);
            warehouse.Deliver(iPhone11, 1);

            warehouse.ShowStock();

            Cart cart = shop.Cart();

            try
            {
                cart.Add(iPhone12, 4);
                cart.Add(iPhone11, 3);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }

            cart.ShowGoods();

            Console.WriteLine(cart.Order().Paylink);

            try
            {
                cart.Add(iPhone12, 9);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
