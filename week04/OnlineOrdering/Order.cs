using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // Calculates the total price of the order, including shipping
        public double GetTotalPrice()
        {
            double subtotal = 0;

            foreach (Product product in _products)
            {
                subtotal += product.GetTotalCost();
            }

            double shippingCost = _customer.LivesInUSA() ? 5.0 : 35.0;

            return subtotal + shippingCost;
        }

        // Returns the packing label: one line per product with name and ID
        public string GetPackingLabel()
        {
            string label = "";

            foreach (Product product in _products)
            {
                label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
            }

            return label;
        }

        // Returns the shipping label: customer name and full address
        public string GetShippingLabel()
        {
            return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
        }
    }
}
