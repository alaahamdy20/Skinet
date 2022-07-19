namespace Skinet.Dtos;

public class ProductToReturnDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Descraption { get; set; }
    public string PictureURL { get; set; }
    public decimal  Price { get; set; }
    public string ProductType { get; set; }
    public string ProductBrand { get; set; }
}