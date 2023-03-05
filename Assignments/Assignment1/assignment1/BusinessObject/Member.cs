using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("MEMBER")]
public class Member
{
    [Column("MEMBER_ID")]
    public int MemberId { get; set; }
    
    [Column("EMAIL")]
    public string Email { get; set; }
    
    [Column("COMPANY_NAME")]
    public string? CompanyName { get; set; }
    
    [Column("CITY")]
    public string? City { get; set; }
    
    [Column("COUNTRY")]
    public string Country { get; set; }
    
    [Column("PASSWORD")]
    public string Password { get; set; }
}