using BusinessObject;
using DataAccess.Repository.IRepository;

namespace DataAccess.Repository;

public class MemberRepository : IMemberRepository
{
    public Member? Login(string email, string password)
    {
        return MemberDAO.Login(email, password);
    }
    
    public List<Member> GetMembers()
    {
        return MemberDAO.GetMembers();
    }
}