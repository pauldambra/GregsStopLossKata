namespace GregsStopLoss
{
    internal struct Pennies
    {
        private readonly static Pennies OneDollarLoss = new Pennies(-100);
        private readonly int _amount;
        
        internal Pennies(int pennies) : this()
        {
            _amount = pennies;
        }

        public static Pennies operator -(Pennies left, Pennies right)
        {
            return new Pennies(left._amount - right._amount);
        }

        public bool IsOneDollarLessThan(Pennies purchasePrice)
        {
            var difference = this - purchasePrice;
            return difference._amount <= OneDollarLoss._amount;
        }

        public override string ToString()
        {
            return _amount.ToString();
        }
    }
}