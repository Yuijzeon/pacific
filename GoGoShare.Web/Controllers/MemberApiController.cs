using GoGoShare.Web.Team2資料庫;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoGoShare.Web.Controllers;

public class MemberApiController(Team2Context context) : ControllerBase
{
    [HttpGet("api/members")]
    public async Task<ActionResult> GetMembers([FromQuery(Name = "id")] List<int> ids)
    {
        var members = await context.用戶s
            .Where(x => ids.Count == 0 || ids.Contains(x.Id))
            .ToListAsync();

        return Ok(members);
    }

    [HttpGet("api/members/{id:int}")]
    public async Task<ActionResult> GetMembers(int id)
    {
        var member = await context.用戶s.FindAsync(id);
        return Ok(member);
    }

    [HttpPost("api/members")]
    public async Task<ActionResult> PostMembers(用戶 member)
    {
        if (member.Id == 0)
        {
            await context.用戶s.AddAsync(member);
            return Ok();
        }

        var entity = await context.用戶s.FindAsync(member.Id);
        context.Entry(entity).CurrentValues.SetValues(member);
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("api/members/{id:int}")]
    public async Task<ActionResult> DeleteMembers(int id)
    {
        var entity = await context.用戶s.FindAsync(id);
        context.用戶s.Remove(entity);
        await context.SaveChangesAsync();
        return Ok();
    }
}