using ORMApp.Business;
using ORMApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMApp.Views
{
    public class Display
    {
        public Display()
        {
            controller = new ProductController();
            Input();
        }

        private int Close = 6;

        private ProductController controller;

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");

        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: List(); break;
                    case 2: Add(); break;
                    case 3: Update(); break;
                    case 4: Fetch(); break;
                    case 5: Delete(); break;
                    default:
                        break;
                }
            } while (operation != Close);

        }

        private void Delete()
        {
            Console.Write("Enter ID to delet: ");
            int id = int.Parse(Console.ReadLine());
            controller.Delete(id);
            Console.WriteLine("Done");
        }

        private void Fetch()
        {
            Console.Write("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            var prod = this.controller.Get(id);
            if (prod != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Product ID: " + prod.Id);
                Console.WriteLine("Product Name: " + prod.Name);
                Console.WriteLine("Product Price: " + prod.Price);
                Console.WriteLine("Product Stock: " + prod.Stock);
                Console.WriteLine(new string('-', 40));

            }
        }

        private void Update()
        {
            Console.Write("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var prod = this.controller.Get(id);
            if (prod != null)
            {
                Console.Write("Enter product name: ");
                prod.Name = Console.ReadLine();
                Console.Write("Enter product price: ");
                prod.Price = decimal.Parse(Console.ReadLine());
                Console.Write("Enter product stock: ");
                prod.Stock = int.Parse(Console.ReadLine());
                this.controller.Update(prod);
            }
        }

        private void Add()
        {
            Product prod = new Product();
            Console.Write("Enter product name: ");
            prod.Name = Console.ReadLine();
            Console.Write("Enter product price: ");
            prod.Price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter product stock: ");
            prod.Stock = int.Parse(Console.ReadLine());
            this.controller.Add(prod);
        }

        private void List()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "PRODUCTS" + new string(' ', 16));
            Console.WriteLine(new string(' ', 40));
            var products = this.controller.GetAll();
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.Id} {prod.Name} {prod.Price} {prod.Stock}");
            }
        }
    }
}
