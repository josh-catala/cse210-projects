using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingSystem
{
    /// <summary>
    /// Represents an order containing a customer and a list of products.
    /// </summary>
    public class Order
    {
        private const double DOMESTIC_SHIPPING_COST = 5.00;
        private const double INTERNATIONAL_SHIPPING_COST = 35.00;

        private Customer _customer;
        private List<Product> _products;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public Order(Customer customer, List<Product> products)
        {
            _customer = customer;
            _products = new List<Product>(products);
        }

        public Customer GetCustomer()
        {
            return _customer;
        }

        public void SetCustomer(Customer customer)
        {
            _customer = customer;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        /// <summary>
        /// The shipping cost for this order, based on where the customer lives.
        /// </summary>
        public double GetShippingCost()
        {
            if (_customer.LivesInUSA())
            {
                return DOMESTIC_SHIPPING_COST;
            }

            return INTERNATIONAL_SHIPPING_COST;
        }

        /// <summary>
        /// The total price of the order: the sum of each product's total cost
        /// plus a one-time shipping cost.
        /// </summary>
        public double GetTotalCost()
        {
            double productsTotal = 0.0;

            foreach (Product product in _products)
            {
                productsTotal = productsTotal + product.GetTotalCost();
            }

            double totalCost = productsTotal + GetShippingCost();
            return totalCost;
        }

        /// <summary>
        /// Returns a packing label listing the name and product id of each
        /// product in the order.
        /// </summary>
        public string GetPackingLabel()
        {
            StringBuilder packingLabel = new StringBuilder();
            packingLabel.Append("PACKING LABEL\n");
            packingLabel.Append("-------------\n");

            foreach (Product product in _products)
            {
                packingLabel.Append(product.GetName());
                packingLabel.Append(" (ID: ");
                packingLabel.Append(product.GetProductId());
                packingLabel.Append(") - Qty: ");
                packingLabel.Append(product.GetQuantity());
                packingLabel.Append("\n");
            }

            return packingLabel.ToString();
        }

        /// <summary>
        /// Returns a shipping label listing the customer's name and address.
        /// </summary>
        public string GetShippingLabel()
        {
            StringBuilder shippingLabel = new StringBuilder();
            shippingLabel.Append("SHIPPING LABEL\n");
            shippingLabel.Append("--------------\n");
            shippingLabel.Append(_customer.GetName());
            shippingLabel.Append("\n");
            shippingLabel.Append(_customer.GetAddress().GetFullAddress());

            return shippingLabel.ToString();
        }
    }
}
