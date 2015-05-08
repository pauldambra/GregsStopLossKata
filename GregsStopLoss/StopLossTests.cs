using NUnit.Framework;

namespace GregsStopLoss
{
    internal class stop_loss_tests : IHandle<Sell>
    {
        private Sell _stockToSell;

        public void Handle(Sell command)
        {
            _stockToSell = command;
        }

        [Test]
        public void a_stock_whose_price_goes_down_sells_when_price_change_meets_threshold()
        {
            _stockToSell = null;
            var purchasePrice = new Pennies(1298);
            var stock = new Stock(purchasePrice, this);

            stock.PriceChanged(new Pennies(1198));

            Assert.That(_stockToSell, Is.EqualTo(new Sell(stock, new Pennies(1198))));
        }

        [Test]
        public void a_stock_whose_price_goes_down_sells_when_price_change_exceeds_threshold()
        {
            _stockToSell = null;
            var purchasePrice = new Pennies(1298);
            var stock = new Stock(purchasePrice, this);

            stock.PriceChanged(new Pennies(1100));

            Assert.That(_stockToSell, Is.EqualTo(new Sell(stock, new Pennies(1100))));
        }

        [Test]
        public void a_stock_whose_price_goes_down_does_not_sell_when_price_change_is_under_threshold()
        {
            _stockToSell = null;
            var purchasePrice = new Pennies(1298);
            var stock = new Stock(purchasePrice, this);

            stock.PriceChanged(new Pennies(1297));

            Assert.That(_stockToSell, Is.Null);
        }

        [Test]
        public void a_stock_whose_price_goes_up_does_not_sell()
        {
            _stockToSell = null;

            var purchasePrice = new Pennies(5000);
            var stock = new Stock(purchasePrice, this);

            stock.PriceChanged(new Pennies(7000));

            Assert.That(_stockToSell, Is.Null);
        }

        [Test]
        public void a_stock_whose_price_goes_up_sells_at_a_new_price()
        {
            _stockToSell = null;

            var purchasePrice = new Pennies(5000);
            var stock = new Stock(purchasePrice, this);

            stock.PriceChanged(new Pennies(7000));

            Assert.That(_stockToSell, Is.Null);

            stock.PriceChanged(new Pennies(6800));

            Assert.That(_stockToSell, Is.EqualTo(new Sell(stock, new Pennies(6800))));
        }

        [Test]
        public void a_stock_has_a_purchase_price()
        {
            var purchasePrice = new Pennies(1845);

            var stock = new Stock(purchasePrice, this);

            Assert.That(stock.LatestPrice, Is.EqualTo(purchasePrice));
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
