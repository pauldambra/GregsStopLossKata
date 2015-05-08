using System;

namespace GregsStopLoss
{
    internal class Sell : IEquatable<Sell>
    {
        public Stock Stock { get; private set; }
        public Pennies AtPrice { get; private set; }

        public Sell(Stock stock, Pennies atPrice)
        {
            Stock = stock;
            AtPrice = atPrice;
        }

        public bool Equals(Sell other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AtPrice.Equals(other.AtPrice) && Equals(Stock, other.Stock);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Sell) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (AtPrice.GetHashCode()*397) ^ (Stock != null ? Stock.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Sell left, Sell right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Sell left, Sell right)
        {
            return !Equals(left, right);
        }
    }
}