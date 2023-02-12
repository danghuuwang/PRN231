using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("ORDER_DETAIL")]
public class OrderDetail
{
    [Column("ORDER_ID")]
    public int OrderId { get; set; }
    
    [Column("PRODUCT_ID")]
    public int ProductId { get; set; }
    
    [Column("QUANTITY")]
    public int Quantity { get; set; }
    
    [Column("DISCOUNT")]
    public int Discount { get; set; }
}