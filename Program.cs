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
                        4. Edit a Product
                        5. View Products by Type"); // New option for viewing products by type

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
        AddProduct();
    }
    else if (choice == "3")
    {
        Console.Clear(); // Clears the console before displaying the message
        DeleteProduct();
    }
    else if (choice == "4")
    {
        Console.Clear(); // Clears the console before displaying the message
        UpdateProduct();
    }
    else if (choice == "5") // New option for viewing products by type
    {
        Console.Clear(); // Clears the console before displaying the message
        ViewProductsByType();
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
    string productString = $"{product.Name} is priced at ${product.Price} and is {(product.IsAvailable ? "available" : $"not available")} at this time.";
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
void AddProduct()
{
    Console.WriteLine("Please enter new product details.");

    Console.Write("Name: ");
    string name = Console.ReadLine();

    Console.Write("Price (use exactly two decimal points): ");
    decimal price;
    while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
    {
        Console.WriteLine("Invalid response. Price should be a positive number with exactly two decimal points.");
        Console.Write("Price: ");
    }



    Console.WriteLine("Available Product Types:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
    }

    Console.Write("Choose the corresponding Product Type (enter the corresponding number): ");
    int productTypeId;
    while (!int.TryParse(Console.ReadLine(), out productTypeId) || productTypeId < 1 || productTypeId > productTypes.Count)
    {
        Console.WriteLine("Invalid input. Please choose a valid Product Type.");
        Console.Write("Choose the corresponding Product Type (enter the corresponding number): ");
    }

    int newProductId = products.Count > 0 ? products.Max(p => p.ProductId) + 1 : 1;

    Product newProduct = new Product()
    {
        ProductId = newProductId,
        Name = name,
        Price = price,
        IsAvailable = true,
        ProductTypeId = productTypeId
    };

    products.Add(newProduct);

    Console.WriteLine($"The Product '{name}' has been posted successfully!");
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}


void DeleteProduct()
{
    Console.WriteLine("Enter the ID of the product you want to delete:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    try
    {
        int ProductNumber = int.Parse(Console.ReadLine());
        if (ProductNumber >= 1 && ProductNumber <= products.Count)
        {
            products.RemoveAt(ProductNumber -  1);
            Console.WriteLine("Product was successfully deleted.");
        }
        else
        {
            Console.WriteLine("Invalid plant number. Please choose a valid number.");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}


void UpdateProduct()
{
    Console.WriteLine("Enter the ID of the product you want to update:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    try
    {
        int productNumber = int.Parse(Console.ReadLine());
        if (productNumber >= 1 && productNumber <= products.Count)
        {
            // Get the product to be updated
            Product productToUpdate = products[productNumber - 1];

            // Update product name
            Console.Write("Enter the new name for the product: ");
            string newName = Console.ReadLine();
            productToUpdate.Name = newName;

            // Update product price
            Console.Write("Enter the new price for the product: $");
            decimal newPrice;
            while (!decimal.TryParse(Console.ReadLine(), out newPrice) || newPrice < 0)
            {
                Console.WriteLine("Invalid input. Price should be a positive number.");
                Console.Write("Enter the new price for the product: $");
            }
            productToUpdate.Price = newPrice;

            // Update product type
            Console.WriteLine("Choose the corresponding product type:");
            DisplayProductTypes();
            int newProductTypeId;
            while (!int.TryParse(Console.ReadLine(), out newProductTypeId) || !IsValidProductTypeId(newProductTypeId))
            {
                Console.WriteLine("Invalid input. Please choose a valid product type.");
                Console.WriteLine("Choose the corresponding product type:");
            }
            productToUpdate.ProductTypeId = newProductTypeId;

            Console.WriteLine("Product was successfully updated.");
        }
        else
        {
            Console.WriteLine("Invalid product number. Please choose a valid number.");
        }
    }
    finally
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}

bool IsValidProductTypeId(int productTypeId)
{
    // Check if the provided product type ID is valid
    return productTypes.Any(pt => pt.ProductTypeId == productTypeId);
}

void DisplayProductTypes()
{
    // Display available product types
    foreach (var productType in productTypes)
    {
        Console.WriteLine($"{productType.ProductTypeId}. {productType.Name}");
    }
}


void DisplayProductsByType(int productTypeId)
{
    Console.WriteLine($"Products of Type {productTypeId}:");
    
    // Filter products based on the selected product type
    var filteredProducts = products.Where(p => p.ProductTypeId == productTypeId).ToList();

    if (filteredProducts.Any())
    {
        for (int i = 0; i < filteredProducts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ProductDetails(filteredProducts[i])}");
        }
    }
    else
    {
        Console.WriteLine("No products found for the selected type.");
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}
void ViewProductsByType()
{
    Console.WriteLine("Product Types:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
    }

    Console.WriteLine("Enter the product type ID to view products:");
    if (int.TryParse(Console.ReadLine(), out int productTypeId))
    {
        DisplayProductsByType(productTypeId);
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}

