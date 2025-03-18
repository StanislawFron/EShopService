namespace EShopService;

public class Product : BaseModel
{
    private string ean { get; set; };
    private decimal price { get; set; };
    private int stock { get; set; };
    private string sku { get; set; };
    private Category category { get; set; };
}
