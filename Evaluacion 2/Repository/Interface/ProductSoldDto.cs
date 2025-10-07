namespace Evaluacion_2.Repository.Interface;

public class ProductSoldDto
{
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
}