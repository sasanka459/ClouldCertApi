using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Web.Resource;
using qansapi.Models;
using QnaBAL.BAL_Abstraction;
using QnaBAL.Models;
using System.Text.RegularExpressions;


namespace qansapi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
  
    public class UserController : ControllerBase
    {
        private readonly IUserBAL _User;
        public UserController(IUserBAL userBAL)
        {
            _User = userBAL;
        }


        [HttpGet (Name="GetUser")]
        public IEnumerable<UserModel> GetUser()
        {
            var userget= _User.GetUser();
            return userget;
        }
/*
        [RequiredScope("AddNewUser")]
        [HttpPost(Name = "AddUser")]
        public String AddUser([FromBody]User user)
        {
            //Checking wheather user is already present or not using Mobile number
            bool Isuserexist;
            Isuserexist = _context.Users.Any(x => x.MobileNo == user.MobileNo);
            if(Isuserexist)
            {
                return "User exist";
            }
            *//*
             checking for valid phone number and EmailID
            *//*
            if (!Validation.EmailValidation(user.Email))
            {
                return "Invalid Email";
            }
            else if (!Validation.PhoneNumberValidation(user.MobileNo))
            {
                return "Invalid MobileNo";
            }
            else
            {
                if (user.PasswordHash != null)
                {
                    user.PasswordHash = Validation.EncryptPassword(user.PasswordHash);
                }
                _context.Users.Add(user);
                //to save the changes in database 
                _context.SaveChanges();
                return "User Added";
            }
              
        }*/
            
            

        }
       
    }

