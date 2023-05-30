// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Text;

namespace Warehouse;

class Program
{
    static void Main(string[] args)
    {
        string[] products = File.ReadAllLines("store.txt", Encoding.UTF8);
        while (true)
        {
            Console.WriteLine("a - list of products\nb - add new product\nc - sell product\n");
            string userInput = Console.ReadLine();
            if (userInput == "a")
            {
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            } else if (userInput == "b")
            {
                Console.Write("Input new product name: ");
                string newProductName = Console.ReadLine();
                Console.Write("Input new product quantity: ");
                int newProductQuantity = int.Parse(Console.ReadLine());
                bool flag = true;
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i].StartsWith(newProductName)) {
                        var temp = products[i].Split()[1];
                        products[i] = newProductName + " " + (int.Parse(temp) + newProductQuantity);
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    string[] newProds = new string[products.Length + 1];
                    for (int i = 0; i < products.Length; i++)
                    {
                        newProds[i] = products[i];
                    }
                    newProds[newProds.Length - 1] = newProductName + " " + newProductQuantity;
                    products = newProds;
                }
                File.WriteAllLines("store.txt", products);
            } else if (userInput == "c")
            {
                Console.Write("Input the product name you want to sell: ");
                string productName = Console.ReadLine();
                Console.Write("Input the quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());
                bool productExists = false;
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i].StartsWith(productName))
                    {
                        productExists = true;
                        var temp = products[i].Split()[1];
                        var check = int.Parse(temp) - productQuantity;
                        if (check < 0)
                        {
                            Console.WriteLine("Not enough products in the list");
                        }
                        else
                        {
                            products[i] = productName + " " + check;
                        }
                    }
                }
                if (!productExists)
                {
                    Console.WriteLine("\nProduct does not exist");
                }
            }
        }
    }
}
