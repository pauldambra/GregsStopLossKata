namespace GregsStopLoss
{
    /// <summary>
    /// The general idea is that when you buy into a stock at a price say $10.
    ///  You want it to automatically get sold if the stock goes below $9 (-$1). 
    ///
    /// If we use the term "trailing" that means that id the price goes up to $11 then the sell point becomes $10.
    /// </summary>
    internal class Stock
    {
        private readonly IHandle<Sell> _saleHandler;
        private Pennies _latestPrice;
        public Pennies PurchasePrice { get; private set; }

        internal Stock(Pennies purchasePrice, IHandle<Sell> saleHandler)
        {
            _saleHandler = saleHandler;
            PurchasePrice = purchasePrice;
        }

        public void PriceChanged(Pennies newPrice)
        {
            _latestPrice = newPrice;
            if (_latestPrice.IsOneDollarLessThan(PurchasePrice))
            {
                _saleHandler.Handle(new Sell(this));
            }
        }

        public Pennies LatestPrice
        {
            get { return _latestPrice; }
        }
    }
}