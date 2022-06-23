using asper_back.Models;

namespace asper_back.Services;

public static class UserService
{
    static List<User> Users { get; } 
    
    static int nextId = 3;
    static UserService() 
    {
        Users = new List<User>
        {
            new User { id = 1, name = "John Doe", isAdmin = false }
            new User { id = 2, name = "Jane Doe", isAdmin = false }

        };
    }

    public static List<User> GetAll() => Users;

    public static void Add(User user) 
    {
        user.id = nextId++;
        Users.Add(user);
    }

    // TO-DO add delete and update methods.
    // from https://docs.microsoft.com/en-us/learn/modules/build-web-api-aspnet-core/5-exercise-add-data-store


}