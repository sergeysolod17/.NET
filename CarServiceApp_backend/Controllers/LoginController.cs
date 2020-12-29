using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarServiceApp_backend.Models;
using CarServiceApp_backend.Services;

namespace CarServiceApp_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {        
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта User
                CarServiceApp_backend.Models.User.Request request = new User.Request{email="serge17@gmail.com", password = "fdg15sd", name = "Sergey"};
                User user1 = new User(request);                
                 // добавляем их в бд
                db.Users.Add(user1);
                                
                db.SaveChanges();                 
                // получаем объекты из бд и выводим на консоль
                var users = new List<User>();//db.Users.ToList();
                return users;                
            }           
        }
    }
}
