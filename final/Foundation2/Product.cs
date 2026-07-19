using System;

namespace OrderingSystem
{
    /// <summary>
    /// Represents a single product line item within an order.
    /// </summary>
    public class Product
    {
        private string _name;
        private string _productId;
        private double _pricePerUnit;
        private int _quantity;

        public Product(string name, string productId, double pricePerUnit, int quantity)
        {
            _name = name;
            _productId = productId;
            _pricePerUnit = pricePerUnit;
            _quantity = quantity;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetProductId()
        {
            return _productId;
        }

        public void SetProductId(string productId)
        {
            _productId = productId;
        }

        public double GetPricePerUnit()
        {
            return _pricePerUnit;
        }

        public void SetPricePerUnit(double pricePerUnit)
        {
            _pricePerUnit = pricePerUnit;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }

        /// <summary>
        /// The total cost of this product line item:
        /// price per unit multiplied by quantity.
        /// </summary>
        public double GetTotalCost()
        {
            double totalCost = _pricePerUnit * _quantity;
            return totalCost;
        }
    }
}
