// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

List<Product> products = new List<Product>()
{
    new Product()
    {
        ProductId = 1,
        Name = "Pointy Hat",
        Price = 10.23M,
        IsAvailable = true,
        ProductTypeId = 1
    },
    new Product()
    {
        ProductId = 2,
        Name = "Black Fire Potion",
        Price = 50.24M,
        IsAvailable = false,
        ProductTypeId = 2
    },
    new Product()
    {
        ProductId = 3,
        Name = "Cloak of Invisibility",
        Price = 150.54M,
        IsAvailable = false,
        ProductTypeId = 3
    },
    new Product()
    {
        ProductId = 2,
        Name = "15inch Wood Wand",
        Price = 5.29M,
        IsAvailable = true,
        ProductTypeId = 4
    }
};

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        ProductTypeId = 1,
        Name = "Apparel"
    },
    new ProductType()
    {
        ProductTypeId = 2,
        Name = "Potions"
    },
    new ProductType()
    {
        ProductTypeId = 3,
        Name = "Enchanted Objects"
    },
    new ProductType()
    {
        ProductTypeId = 4,
        Name = "Wands"
    }
};

string greeting = @"Welcome to Wizard Workshop
Your one-stop shop for Magic Stuff";

Console.WriteLine(greeting);


string choice = null;
while (choice != "0")
{
    Console.Clear(); // Clears the console before displaying the menu

    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. Display All Products
                        2. Add a Product
                        3. Delete a Product
                        4. Edit a Product");

    choice = Console.ReadLine();
    
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        Console.Clear(); // Clears the console before displaying the message
        DisplayAllProducts();
    }
    else if (choice == "2")
    {
        Console.Clear(); // Clears the console before displaying the message
        throw new NotImplementedException("Add a Product");
    }
    else if (choice == "3")
    {
        Console.Clear(); // Clears the console before displaying the message
        throw new NotImplementedException("Delete A Product");
    }
    else if (choice == "4")
    {
        Console.Clear(); // Clears the console before displaying the message
        throw new NotImplementedException("Edit A Product");
    }
    else
    {
        Console.Clear(); // Clears the console before displaying the error message
        Console.WriteLine("Choose an option that is listed. Press any key to continue");
        Console.ReadKey(); // Pauses the program until the user presses any key
    }
}

string ProductDetails(Product product)
{
    string productString = $"{product.Name} is sold for ${product.Price} and is {(product.IsAvailable ? "available" : $"not available")} at this time.";
    return productString;
}

void DisplayAllProducts()
{
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i +1}. {ProductDetails(products[i])}");
    }
    Console.WriteLine("press any key to continue...");
    Console.ReadKey();
}