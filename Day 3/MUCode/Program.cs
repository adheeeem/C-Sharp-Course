// See https://aka.ms/new-console-template for more information
using UnmanagedCode;

while (true)
{
    Console.WriteLine("r - to read\nw - to write");
    string option = Console.ReadLine();
    if (option == "r")
    {
        using (Application app = new Application("input.txt"))
        {
            Console.WriteLine(app.ReadFromFile());
        }
    }
    else if (option == "w")
    {
        using (Application app = new Application("input.txt"))
        {
            Console.Write("Input something: ");
            string txt = Console.ReadLine();
            app.WriteToFile(txt);
        }

    }
}