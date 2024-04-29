using _20201132039_SinavPortali.Dtos;
using _20201132039_SinavPortali.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _20201132039_SinavPortali.Controllers
{
    [Authorize(Roles = "Admin, Student")]
    [Route("api/[Controller]")]
    [ApiController]
    public class AppUserCourseController : Controller
    {
        private readonly AppDbContext _context;

        Response _resultDto = new Response();


        public AppUserCourseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<Response> AddCourseToUserRelationship(string userId, int courseId)
        {
            var course = await _context.Course.AnyAsync(o => o.Id == courseId);
            if (!course)
            {
                _resultDto.Status = false;
                _resultDto.Message = "Seçenek bulunamadı!";
                return _resultDto;
            }

            var user = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!user) 
            {
                _resultDto.Status = false;
                _resultDto.Message = "Kullanıcı bulunamadı!";
                return _resultDto;
            }
            var appUserCourse = new AppUserCourse { AppUserId = userId, CourseId = courseId };
            _context.AppUserCourse.Add(appUserCourse);
            await _context.SaveChangesAsync();
            _resultDto.Status = true;
            _resultDto.Message = "İlişki Eklendi!";
            return _resultDto;
        }

        [HttpDelete]
        public async Task<Response> DeleteCourseToUserRelationship(string userId, int courseId)
        {
            var appUserCourse = await _context.AppUserCourse
                .FirstOrDefaultAsync(e => e.AppUserId == userId && e.CourseId == courseId);

            var course = await _context.Course.AnyAsync(c => c.Id == courseId);
            if (appUserCourse == null)
            {
                _resultDto.Status = false;
                _resultDto.Message = "İlişki bulunamadı!";
                return _resultDto;
            }

            _context.AppUserCourse.Remove(appUserCourse);
            await _context.SaveChangesAsync();
            _resultDto.Status = true;
            _resultDto.Message = "İlişki silindi!";
            return _resultDto;
        }

    }
}
