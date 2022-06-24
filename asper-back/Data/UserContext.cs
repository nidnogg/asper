using Microsoft.EntityFrameworkCore;
using asper_back.Models;

namespace asper_back.Data;

public class UserContext : DbContext
{
    public UserContext (DbContextOptions<UserContext> options)
        : base(options)
        {
        }
    
    public DbSet<User> Users => Set<User>();
}