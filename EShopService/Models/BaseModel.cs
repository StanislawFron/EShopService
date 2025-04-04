namespace EShopService;

public class BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Boolean Deleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid UpdatedBy { get; set; }
}
