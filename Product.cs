using System.Dynamic;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public int ProductTypeId { get; set; }
}

public class ProductType
{
    public int ProductTypeId { get; set; }
    public string Name { get; set; }
}