using EStoreAPI.API;
using Microsoft.AspNetCore.Mvc;

namespace EStoreAPI.Controllers;

public class MemberController : Controller
{
    [HttpPost]
    [Route("api/login")]
    public IActionResult Login(string email, string password)
    {
        return Ok(MemberAPI.Login(email, password));
    }
    
    [HttpGet]
    [Route("api/members")]
    public IActionResult GetMembers()
    {
        return Ok(MemberAPI.GetMembers());
    }
}