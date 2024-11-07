using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BigEshop.Web.Utilities
{
	public class CheckPermissionAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
	{
		private readonly string permissionName;

		public CheckPermissionAttribute(string permissionName)
		{
			this.permissionName = permissionName;
		}

		public Task OnAuthorizationAsync(AuthorizationFilterContext context)
		{
			var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();

			int currentUserId = context.HttpContext.User.GetUserId();

			if(!userService.UserHasPermission(currentUserId, permissionName))
			{
				context.Result = new RedirectResult("/Login");
			}

			return Task.CompletedTask;
		}
	}
}
