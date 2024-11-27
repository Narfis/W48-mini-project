
int main()
{
    Products products = new Products();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Follow the steps to add products");
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("| Enter s to search | Enter p to print | Enter q to quit |");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter product category: ");
        string? category = Console.ReadLine();

        if (string.IsNullOrEmpty(category))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Category cannot be empty");
            continue;
        }

        if (category.Trim().ToLower().Equals("p"))
        {
            products.PrintProducts();
            continue;
        }

        if (category.Trim().ToLower().Equals("s"))
        {
            Console.Write("Enter search query: ");
            string? query = Console.ReadLine();
            if (string.IsNullOrEmpty(query))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Query cannot be empty");
                continue;
            }
            products.PrintProducts(query);
            continue;
        }

        if (category.Trim().ToLower().Equals("q"))
        {
            return 0;
        }

        Console.Write("Enter product name: ");
        string? name = Console.ReadLine();

        if (string.IsNullOrEmpty(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Name cannot be empty");
            continue;
        }

        Console.Write("Enter product price: ");

        if (!float.TryParse(Console.ReadLine(), out float price))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Price must be a number");
            continue;
        }

        Product product = new Product(category, name, price);

        products.AddProduct(product);
    }
}


main();