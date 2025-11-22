using System;

namespace OnlineOrdering
{
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

        public Address GetAddress()
        {
            return _address;
        }

        // Returns true if the customer lives in the USA
        public bool LivesInUSA()
        {
            return _address.IsInUSA();
        }
    }
}
