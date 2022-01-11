using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Authentication
{
    public class AuthenticationError
    {
        public string Code { get; set; } // 202 UserNotfound
        public string Message { get; set; } // Böyle bir kullanıcı sistem bulunamadı!

        public string Key { get; set; } // UserName
    }
    public class AuthenticationResult
    {
        public bool IsSucceded { get; private set; } = true;
        public string AccessToken { get; private set; }
        public List<AuthenticationError> Errors { get; private set; }

        public void AddError(AuthenticationError error)
        {
            IsSucceded = false;
            Errors.Add(error);
        }

        public void SetAccessToken(string token)
        {
            if (IsSucceded)
            {
                AccessToken = token;
            }
            
        }
    }

    public interface IAuthenticationService
    {

        /// <summary>
        /// Login olduktan sonra remember true olursa bu token 1 aylık bir token olsun diğer türlü 1 günlük token oluşturacağız.
        /// JWT JSon web Token
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="rememberMe"></param>
        /// <returns></returns>
        AuthenticationResult Login(string email, string password, bool rememberMe);
        void LogOut(string accessToken); // kullanıcıya giriş işlemleri için verilen accessToken expire edeceğiz.artık bu access token geçersiz olacak. Kullanıcının sitemden güvenli çıkışı için var.

    }
}
