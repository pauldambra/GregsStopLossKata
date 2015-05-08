using NUnit.Framework;

namespace GregsStopLoss
{
    class stop_loss_tests : IHandle<Sell>
    {
        private Stock _stockToSell;
        
        public void Handle(Sell command)
        {
            _stockToSell = command.Stock;
        }

        [Test]
        public void a_stock_can_be_sold()
        {
            _stockToSell = null;
            var purchasePrice = new Pennies(1298);
            var stock = new Stock(purchasePrice, this);
            
            stock.PriceChanged(new Pennies(1297));

            Assert.That(_stockToSell.LatestPrice, Is.EqualTo(new Pennies(1297)));
        }

        [Test]
        public void a_stock_has_a_purchase_price()
        {
            var purchasePrice = new Pennies(1845);

            var stock = new Stock(purchasePrice, this);
            
            Assert.That(stock.PurchasePrice, Is.EqualTo(purchasePrice));
        }

        [Test]
        public void changing_price_has_some_impact()
        {
            var stock = new Stock(new Pennies(1235), this);

            stock.PriceChanged(new Pennies(1500));

            Assert.That(stock.LatestPrice, Is.EqualTo(new Pennies(1500)));
        }
    }
}
