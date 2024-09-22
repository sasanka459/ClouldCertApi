using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using qans.BusinessAccessLayer.Abstraction;
using qans.BusinessAccessLayer.Models;


namespace qansapi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        public readonly IUserService _UserService;
        public UserController(IUserService userService)
        {
            _UserService = userService;
        }

        //[HttpGet (Name="GetUser")]
        //public IEnumerable<User> GetUser()
        //{
        //  //  return _context.Users.ToList();
        //}

        [RequiredScope("AddNewUser")]
        [HttpPost(Name = "AddUser")]
        public String AddUser([FromBody] User user)
        {
         
            return _UserService.SaveUser(user);
              
        }
            

        }
       
    }

