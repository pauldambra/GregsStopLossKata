using System.Runtime.InteropServices.ComTypes;

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

        public Pennies LatestPrice { get; private set; }

        internal Stock(Pennies purchasePrice, IHandle<Sell> saleHandler)
        {
            LatestPrice = purchasePrice;
            _saleHandler = saleHandler;
        }

        public void PriceChanged(Pennies newPrice)
        {
            if (newPrice.IsOneDollarLessThan(LatestPrice))
            {
                _saleHandler.Handle(new Sell(stock: this, atPrice: newPrice));
            }
            else
            {
                LatestPrice = newPrice;
            }
        }
    }
}