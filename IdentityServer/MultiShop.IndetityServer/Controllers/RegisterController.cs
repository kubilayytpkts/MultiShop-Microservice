using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IndetityServer.Dtos;
using MultiShop.IndetityServer.Models;
using System.Threading.Tasks;

namespace MultiShop.IndetityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(RegisterDto register)
        {
            var user =new ApplicationUser{ 
            Email = register.Email,
            Name = register.Name,
            Surname = register.Surname,
            UserName = register.Username,
            };

            var resultCreateUser =await _userManager.CreateAsync(user, register.Password);

            if (resultCreateUser.Succeeded)
                return Ok("Kullanıcı Ekleme Başarılı");

            else
                return Ok("Bir Hata Oluştu !");
        }
    }
}
