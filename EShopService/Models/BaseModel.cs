namespace EShopService;

public class BaseModel
{
    private int id { get; set; };
    private string name { get; set; };
    private Bool deleted { get; set; };
    private DateTime created_at { get; set; };
    private Guid created_by { get; set; };
    private DateTime updated_at { get; set; };
    private Guid updated_by { get; set; };
}
