using System;
using System.Text;

public class Product
{
    public string[] prods { get; set; }
    public Product()
	{
        prods = File.ReadAllLines("store.txt", Encoding.UTF8);
    }

    public Product(string name, int count)
    {
        SaveToFile(name, count);
    }

    public void SaveToFile(string name, int count)
    {
        string[] newProds = new string[prods.Length + 1];
        for (int i = 0; i < prods.Length; i++)
        {
            newProds[i] = prods[i];
        }
        newProds[newProds.Length - 1] = name + " " + count;  
        File.WriteAllLines("store.txt", newProds);
    }

    public static string[] GetPorducts(string filePath)
    {
        return File.ReadAllLines(filePath, Encoding.UTF8);
    }

    public static bool ProductExists(string name, string filePath)
    {
        var prods = File.ReadAllLines(filePath, Encoding.UTF8);
        foreach (var item in prods)
        {
            if (item.StartsWith(name))
            {
                return true;
            }
        }
        return false;
    }

    public void ChangeNumber(string name, int n)
    {
        for (int i = 0; i < prods.Length; i++)
        {
            if (prods[i].StartsWith(name))
            {
                var temp = int.Parse(prods[i].Split()[1]);
                if (n + temp >= 0)
                {
                    prods[i] = name + " " + (temp + n);
                    File.WriteAllLines("store.txt", prods);
                    break;
                }
                else
                {
                    Console.WriteLine("Not enough products");
                }
            }
        }
    }


}
