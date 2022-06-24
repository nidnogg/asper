using asper_back.Models;
using asper_back.Services;
using Microsoft.AspNetCore.Mvc;

namespace asper_back.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase 
{
    public UserController()
    {

    }
    // GET all action
    [HttpGet]
    public ActionResult<List<User>> GetAll() => UserService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = UserService.Get(id);
        
        if(user == null) return NotFound();
        
        return user;
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        if(user == null) return BadRequest();

        UserService.Add(user);

        return CreatedAtAction(nameof(Create), new { id = user.id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, User user)
    {
        if(id != user.id) return BadRequest();
        
        var existingUser = UserService.Get(id);
        if(user == null) return NotFound();


        Console.WriteLine($"Updating user with id = {user.id}");
        UserService.Update(user);
        Console.WriteLine($"Successfully updated user with id = {user.id}");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = UserService.Get(id);
        if(user == null) return NotFound();

        UserService.Delete(id);

        return NoContent();
    }

}
    
