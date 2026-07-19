using System;

namespace OrderingSystem
{
    /// <summary>
    /// Represents a customer who places an order.
    /// </summary>
    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public Address GetAddress()
        {
            return _address;
        }

        public void SetAddress(Address address)
        {
            _address = address;
        }

        /// <summary>
        /// Returns whether this customer lives in the USA by
        /// delegating to the Address class.
        /// </summary>
        public bool LivesInUSA()
        {
            return _address.IsInUSA();
        }
    }
}
