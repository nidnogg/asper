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
            new User { id = 1, name = "John Doe", isAdmin = false },
            new User { id = 2, name = "Jane Doe", isAdmin = false }
        };
    }

    public static List<User> GetAll() => Users;

    public static User? Get(int id) => Users.FirstOrDefault(p => p.id == id);

    public static void Add(User user) 
    {
        user.id = nextId++;
        Users.Add(user);
    }

    public static void Delete(int id) 
    {
        var user = Get(id);
        if(user is null) return;

        Users.Remove(user);
    }

    public static void Update(User user)
    {
        var idx = Users.FindIndex(p => p.id == user.id);
        if(idx == -1) return;
        Users[idx] = user;
    }
    // TO-DO add delete and update methods.
    // from https://docs.microsoft.com/en-us/learn/modules/build-web-api-aspnet-core/5-exercise-add-data-store


}