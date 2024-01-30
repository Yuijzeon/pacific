using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GoGoShare.Web;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RequireLoginAttribute(string redirectUrl = "/SignUp/Index") : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var memberId = context.HttpContext.Session.GetInt32("ID");

        if (memberId is null)
        {
            context.Result = new RedirectResult(redirectUrl);
            return;
        }

        context.ActionArguments["memberId"] = memberId;
        await next();
    }
}