using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("ORDER")]
public class Order
{
    [Column("ORDER_ID")]
    public int OrderId { get; set; }
    
    [Column("MEMBER_ID")]
    public int MemberId { get; set; }

    [Column("ORDER_DATE")]
    public DateTime OrderDate { get; set; }
    
    [Column("REQUIRED_DATE")]
    public DateTime RequiredDate { get; set; }
    
    [Column("SHIPPED_DATE")]
    public DateTime ShippedDate { get; set; }
    
    [Column("FRIEGHT")]
    public bool Freight { get; set; }
}