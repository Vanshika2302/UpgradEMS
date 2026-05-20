using UpGradEMS.DAL.Data;
using UpGradEMS.DAL.Models;

public class UserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Register(UserInfo user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public UserInfo? Login(string email, string password)
    {
        return _context.Users
            .FirstOrDefault(u => u.EmailId == email && u.Password == password);
    }
}