using System;

namespace OnlineOrdering
{
    public class Address
    {
        private string _streetAddress;
        private string _city;
        private string _stateProvince;
        private string _country;

        public Address(string streetAddress, string city, string stateProvince, string country)
        {
            _streetAddress = streetAddress;
            _city = city;
            _stateProvince = stateProvince;
            _country = country;
        }

        // Returns true if the address is in the USA
        public bool IsInUSA()
        {
            return _country.Trim().ToUpper() == "USA";
        }

        // Returns the full address as a single string
        public string GetFullAddress()
        {
            return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
        }
    }
}
