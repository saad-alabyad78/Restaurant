using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Restaurants.Application.Users;

public interface IUserContext
{
    public CurrentUser? GetCurrentUser() ;
}
public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User ;

        if(user is null)
        {
            throw new InvalidOperationException("user context is not present") ;
        }
        if(user.Identity == null ||  user.Identity.IsAuthenticated == false)
        {
            return null ;
        }

        var id = user.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value ;
        var email = user.FindFirst(claim => claim.Type == ClaimTypes.Email)?.Value ;
        var roles = user.Claims.Where(claim => claim.Type == ClaimTypes.Role).Select(c => c.Value);

        if(id == null || email == null)
        {
            throw new Exception("id or email is null") ;
        }

        return new CurrentUser(Id: id , Email:email , Roles: roles) ;
    }
}