using BusinessObject;

namespace DataAccess.Repository.IRepository;

public interface IMemberRepository
{
    Member? Login(string email, string password);
    List<Member> GetMembers();
}