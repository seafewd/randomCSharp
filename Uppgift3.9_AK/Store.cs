using System;
using System.Collections.Generic;

namespace Uppgift3._9_AK
{
    class Store
    {
        
        static void Main(string[] args)
        {
            Store store = new Store();
            List<Product> inventory = new List<Product>();

            Console.WriteLine("Welcome to the store!");

            store.addProducts(inventory);
            store.printInventory(inventory);
          
        }

        public void printInventory(List<Product> inventory)
        {
            foreach (Product p in inventory)
                Console.WriteLine(p.Name + "\t\t\t" + "Weight: " + p.Weight + "kg\t\t\t" + "$" + p.Price + "\t\t\tAmount left: " + p.Quantity);
        }

        public void addProducts(List<Product> inventory)
        {
            Product pasta = new Product("Pasta", 2.99, 0.9, 4);
            Product tomatoSauce = new Product("Tomato Sauce", 1.99, 1.2, 5);
            Product lentils = new Product("Lentils", .99, 0.7, 3);
            Product avocado = new Product("Avocado", .99, 0.5, 3);
            Product chocolate = new Product("Chocolate", 1.99, 0.9, 4);
            Product veggieSchnitzel = new Product("Veggie Schnitzel", 4.99, 2.3, 6);

            inventory.Add(pasta);
            inventory.Add(tomatoSauce);
            inventory.Add(lentils);
            inventory.Add(avocado);
            inventory.Add(chocolate);
            inventory.Add(veggieSchnitzel);
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
        int quantity;

        public Product(string name, double price, double weight, int quantity)
        {
            this.name = name;
            this.price = price;
            this.weight = weight;
            this.quantity = quantity;
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
        public double Weight
        {
            get { return weight; }
            set { }
        }

        public int Quantity
        {
            get { return quantity; }
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
