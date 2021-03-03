using System;
using System.Collections.Generic;

namespace Uppgift3._9_AK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Customer
    {
        private Cart cart = new Cart();
        int inventorySpace = 10;

        public Cart getCart() {
            return cart;
        }
    }

    public class Cart
    {
        List<Product> products = new List<Product>();

        List<Product> Products
        {
            get { return products; }
            set { }
        }
    }

    public class Product
    {
        string name;
        double price;
        double weight;

        public Product(string name, double price, double weight)
        {
            this.name = name;
            this.price = price;
            this.weight = weight;
        }

        public string Name 
        {
            get { return name; }
            set { }
        }

        public double Price
        {
            get { return price; }
            set { }
        }
    }

    public class Register
    {
        double total;

        public void ScanProduct(Product product)
        {
            total += product.Price;
        }

        public double Total
        {
            get { return this.total; }
            set { total = value; }
        }
    }
}
