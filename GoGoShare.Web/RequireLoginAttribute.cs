using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GoGoShare.Web;

[AttributeUsage(AttributeTargets.Method)]
public class RequireLoginAttribute(string loginIdParam) : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var userId = context.HttpContext.Session.GetInt32("ID");

        if (userId is null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        context.ActionArguments[loginIdParam] = userId;
        await next();
    }
}