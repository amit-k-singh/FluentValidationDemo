using FluentValidationDemo.Context;
using FluentValidationDemo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FluentValidationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Users.ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id,User user)
        { 
            var userResult = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userResult == null)
            {
                return BadRequest("User does not exiest...!!!");
            }
            userResult.Name = user.Name;
            userResult.Email = user.Email;
            userResult.Address = user.Address;
            userResult.Phone = user.Phone;
            userResult.DOB = user.DOB;
            await _context.SaveChangesAsync();
            return Ok(userResult);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var userResult = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            if ( userResult == null )
            {
                return BadRequest("User not exiest...!!!");
            }
            _context.Users.Remove(userResult);
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }
    }
}
