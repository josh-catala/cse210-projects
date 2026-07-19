using System;

namespace OrderingSystem
{
    /// <summary>
    /// Represents a mailing address.
    /// </summary>
    public class Address
    {
        private string _street;
        private string _city;
        private string _stateOrProvince;
        private string _country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            _street = street;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        public string GetStreet()
        {
            return _street;
        }

        public void SetStreet(string street)
        {
            _street = street;
        }

        public string GetCity()
        {
            return _city;
        }

        public void SetCity(string city)
        {
            _city = city;
        }

        public string GetStateOrProvince()
        {
            return _stateOrProvince;
        }

        public void SetStateOrProvince(string stateOrProvince)
        {
            _stateOrProvince = stateOrProvince;
        }

        public string GetCountry()
        {
            return _country;
        }

        public void SetCountry(string country)
        {
            _country = country;
        }

        /// <summary>
        /// Returns whether this address is located in the USA.
        /// </summary>
        public bool IsInUSA()
        {
            if (_country == null)
            {
                return false;
            }

            string normalizedCountry = _country.Trim().ToLower();

            if (normalizedCountry == "usa"
                || normalizedCountry == "us"
                || normalizedCountry == "u.s."
                || normalizedCountry == "u.s.a."
                || normalizedCountry == "united states"
                || normalizedCountry == "united states of america")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns all of the address fields together as one string,
        /// with newline characters separating each line.
        /// </summary>
        public string GetFullAddress()
        {
            string fullAddress = _street + "\n" + _city + ", " + _stateOrProvince + "\n" + _country;
            return fullAddress;
        }
    }
}
