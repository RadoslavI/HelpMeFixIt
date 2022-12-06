﻿using System.Security.Claims;

namespace HelpMeFixIt.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        //public static bool IsAdmin(this ClaimsPrincipal user)
        //{
        //    return user.IsInRole(AdminRoleName);
        //}
    }
}