using System;
using System.Collections.Generic;

namespace FirstApp
{
    abstract class Delivery
    {
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public abstract void Deliver();
    }

    class HomeDelivery : Delivery
    {
        public override void Deliver()
        {
            Console.WriteLine($"Курьер доставил заказ по адресу {Address}");
        }
    }

    class PickPointDelivery : Delivery
    {
        public override void Deliver()
        {
            Console.WriteLine($"Заказ доставлен в пункт выдачи.");
        }
    }

    class ShopDelivery : Delivery
    {
        public string ShopName { get; set; }
        public override void Deliver()
        {
            Console.WriteLine($"Заказ доставлен в магазин {ShopName}, по адресу {Address}.");
        }
    }

    class Customer
    {
        private string name;
        private string phone;
        private string email;

        public string Phone
        {
            get { return phone; }
            set
            {
                if (value.Length != 12 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Впишите номер в формате +7...");
                }
                phone = value;
                
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }

    class Order<TDelivery, TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery { get; set; }
        private int Number;
        public string Description { get; set; }
        private List<Product> Products;
        private static int OrderNumber;
        private Customer customer;

        public Order(string description, TDelivery delivery)
        {
            OrderNumber++;
            this.Number = OrderNumber;
            this.Description = description;
            this.Delivery = delivery;
            this.customer = new Customer();
            this.Products = new List<Product>();
        }

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

        public void AddProduct(Product item)
        {
            Products.Add(item);
        }
        
        public void RemoveProduct(Product item)
        {
            Products.Remove(item);
        }

    }

    class SpecialOrder<TDelivery, TStruct> : Order<TDelivery, TStruct> where TDelivery:Delivery
    {
        public double Discount { get; set; }
        public SpecialOrder(string description, TDelivery delivery, double discount) : base(description, delivery)
        {
            this.Discount = discount;
        }
    }

    class Product
    {
        private string name;
        private string description;
        private double price;

        public Product(string name, string description, double price)
        {
            this.name = name;
            this.price = price;
            this.description = description;
        }
        
        public double Price
        {
            get { return price; }
            set { if (value < 0)
                    { 
                        throw new ArgumentException("Цена не может быть меньше нуля"); 
                    }
                  price = value;
                }
        }
        
        public void NameOfProduct()
        {
            Console.WriteLine(name);
        }

        
    }



}
