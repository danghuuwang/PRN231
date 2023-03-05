using BusinessObject;
using DataAccess.Repository;
using DataAccess.Repository.IRepository;

namespace EStoreAPI.API;

public class MemberAPI
{
    private static IMemberRepository productRepository = new MemberRepository();
    
    public static Member Login(string email, string password)
    {
        Member? member = productRepository.Login(email, password);
        if (member == null)
        {
            throw new Exception("Invalid email or password");
        }
        return member;
    }
    
    public static List<Member> GetMembers()
    {
        return productRepository.GetMembers();
    }
}