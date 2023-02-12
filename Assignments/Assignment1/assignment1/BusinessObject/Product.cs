using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("PRODUCT")]
public class Product
{
    [Column("PRODUCT_ID")]
    public int ProductId { get; set; }
    
    [Column("CATEGORY_ID")]
    public int CategoryId { get; set; }
    
    [Column("PRODUCT_NAME")]
    public string ProductName { get; set; }
    
    [Column("WEIGHT")]
    public decimal Weight { get; set; }
    
    [Column("UNIT_PRICE")]
    public decimal UnitPrice { get; set; }
    
    [Column("UNITS_IN_STOCK")]
    public int UnitsInStock { get; set; }
}