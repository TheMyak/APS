using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserClaimsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public UserClaimsController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserClaim>>> GetUserClaims()
        {
            return await _context.UserClaims.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserClaim>> GetUserClaim(int id)
        {
            var claim = await _context.UserClaims.FindAsync(id);
            if (claim == null) return NotFound();
            return claim;
        }

        [HttpPost]
        public async Task<ActionResult<UserClaim>> CreateUserClaim(UserClaim claim)
        {
            _context.UserClaims.Add(claim);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserClaim), new { id = claim.Id }, claim);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserClaim(int id, UserClaim claim)
        {
            if (id != claim.Id) return BadRequest();
            _context.Entry(claim).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserClaim(int id)
        {
            var claim = await _context.UserClaims.FindAsync(id);
            if (claim == null) return NotFound();
            _context.UserClaims.Remove(claim);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}