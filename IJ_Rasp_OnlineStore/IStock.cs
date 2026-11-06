namespace IJ_Rasp_OnlineStore
{
    internal interface IStock
    {
        void EnsureAvailable(Good good, int quantity);

        void TakeFromStock(Good good, int quantity);
    }
}
