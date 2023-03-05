using BusinessObject;
using BusinessObject.DBContext;

namespace DataAccess;

public class MemberDAO
{
    public static Member? Login(string email, string password)
    {
        try
        {
            using var context = new DatabaseContext();
            Member? member = context.Members
                .Where(m => m.Email == email)
                .FirstOrDefault(m => m.Password == password);

            return member;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    public static List<Member> GetMembers()
    {
        try
        {
            using var context = new DatabaseContext();
            List<Member> members = context.Members.ToList();

            return members;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}