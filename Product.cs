
class Product
{
    public string Category { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public Product(string category, string name, float price)
    {
        Category = category;
        Name = name;
        Price = price;
    }
}

class Products
{
    public List<Product> ProductList { get; set; }
    public Products()
    {
        ProductList = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        ProductList.Add(product);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Product added");
    }

    private List<Product> SortProducts(List<Product> products)
    {
        return products.OrderBy(p => p.Price).ToList();
    }

    public void PrintProducts()
    {
        var sortedProducts = SortProducts(ProductList);

        if (sortedProducts.Count == 0)
        {
            Console.WriteLine("No products found");
            return;
        }


        Console.WriteLine("Category".PadRight(10) + "Name".PadRight(10) + "Price");
        foreach (var product in sortedProducts)
        {
            Console.WriteLine($"{product.Category.PadRight(10)}{product.Name.PadRight(10)}{product.Price}");
        }

        float sum = sortedProducts.Sum(p => p.Price);

        Console.WriteLine("".PadRight(10) + "Total".PadRight(10) + sum);
    }

    public void PrintProducts(string query)
    {
        var sortedProducts = SortProducts(ProductList);

        if (sortedProducts.Count == 0)
        {
            Console.WriteLine("No products found");
            return;
        }

        var productsToHighlight = sortedProducts.Select(p => p.Name.Contains(query)).ToList();

        Console.WriteLine("Category".PadRight(10) + "Name".PadRight(10) + "Price");
        for(int i = 0; i < sortedProducts.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (productsToHighlight[i])
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            Console.WriteLine($"{sortedProducts[i].Category.PadRight(10)}{sortedProducts[i].Name.PadRight(10)}{sortedProducts[i].Price}");
        }
        Console.ForegroundColor = ConsoleColor.White;

        float sum = sortedProducts.Sum(p => p.Price);
        Console.WriteLine("".PadRight(10) + "Total".PadRight(10) + sum);
    }
}