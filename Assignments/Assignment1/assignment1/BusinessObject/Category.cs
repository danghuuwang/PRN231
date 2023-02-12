using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("CATEGORY")]
public class Category
{
    [Column("CATEGORY_ID")]
    public int CategoryId { get; set; }
    
    [Column("CATEGORY_NAME")]
    public string CategoryName { get; set; }
}