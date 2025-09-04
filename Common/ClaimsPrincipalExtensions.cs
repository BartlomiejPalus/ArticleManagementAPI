﻿using System.Security.Claims;

namespace ArticleManagementAPI.Common
{
	public static class ClaimsPrincipalExtensions
	{
		public static Guid GetUserId(this ClaimsPrincipal user)
		{
			var idClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			return Guid.TryParse(idClaim, out var id) ? id : Guid.Empty;
		}
	}
}
