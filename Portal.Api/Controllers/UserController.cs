using _20201132039_SinavPortali.Dtos;
using _20201132039_SinavPortali.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _20201132039_SinavPortali.Controllers
{
    [Authorize]
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly AppDbContext _context;
        Response _resultDto = new Response();
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController( AppDbContext appDbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult<AppUser>> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) 
            {
                return NotFound();
            }
            return user;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("GetAll")]
        public List<AppUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("ChangeRole/{id}")]
        public async Task<Response> ChangeUserRole(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                _resultDto.Status = false;
                _resultDto.Message = "Kullanıcı Bulunamadı!";
                return _resultDto;
            }
            if (!await _roleManager.RoleExistsAsync(role))
            {
                _resultDto.Status = false;
                _resultDto.Message = "Rol Bulunamadı!";
                return _resultDto;
            }
            await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            await _userManager.AddToRoleAsync(user, role);
            _resultDto.Status = true;
            _resultDto.Message = "Rol Değiştirildi!";
            return _resultDto;
        }

        [HttpPut]
        public async Task<Response> ChangeUserInfo(UserDto dto) 
        {
            var user = await _userManager.FindByIdAsync(dto.Id);
            if(user == null)
            {
                _resultDto.Status = false;
                _resultDto.Message = "Kullanıcı Bulunamadı!";
                return _resultDto;
            }
            user.PhoneNumber = dto.PhoneNumber;
            user.FullName = dto.FullName;

            _resultDto.Status = true;
            _resultDto.Message = "Kullanıcı bilgileri değiştirildi veya eklendi!";
            return _resultDto;
        }
    }
}
