namespace GregsStopLoss
{
    internal class Sell
    {
        public Stock Stock { get; private set; }

        public Sell(Stock stock)
        {
            Stock = stock;
        }
    }
}