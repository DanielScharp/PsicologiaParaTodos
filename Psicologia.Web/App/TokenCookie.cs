using Microsoft.AspNetCore.Http;
using System;

namespace Psicologia.Web.App
{
    public class TokenCookie
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenCookie(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private HttpContext HttpContext => _httpContextAccessor.HttpContext;

        public string Token
        {
            get
            {
                return HttpContext.Request.Cookies["token-l"] != null ? HttpContext.Request.Cookies["token-l"] : "";
            }
            set
            {
                var cookieOptions = new CookieOptions();
                HttpContext.Response.Cookies.Append("token-l", value, cookieOptions);
            }
        }

        public void Logoff()
        {
            try
            {
                var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(-1) };
                HttpContext.Response.Cookies.Append("token-l", "", cookieOptions);
            }
            catch { }
        }
    }
}
