using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Authentication
{
    public class TokenClaim
    {
        public string ClaimType { get; set; } // UserName, Role
        public string ClaimValue { get; set; } // Berkay, Admin

    }

    public class TokenModel
    {
        public string AccessToken { get; set; } // Base64 formatındaki token bilgisi
        public DateTime ExpireDate { get; set; }  // token ne zaman expire olacağı bilgisi

    }

    /// <summary>
    /// Belirli bir süreliğine Access Token üretmek için bu servisi kullanacağız
    /// Tokenda taşınacak bilgiler için TokenClaim adında bir sınıf kullanacağız. Key Value olarak tokenda bilgi saklayacağız.
    /// Token Model ise kullanıcının Access Token ve bu token geçerlilik süresi için açtığımız model
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Sisteme giriş yapacak kullanıcılar için Erişim Bileti Access Token oluşturacağız.
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        TokenModel CreateAccessToken(List<TokenClaim> claims);
        /// <summary>
        ///Kullanıcıya ait Access Token bilgisinin artık kullanılmaması için çalıştıracağımız method. Bu token bilgisi kullanıcıdan geriş alınacaktır. Oturum açmak işleminde bu tokenın bir daha bu kullanıcı tarafından kullanılmaması için var.
        /// </summary>
        /// <param name="token"></param>
        void RevokeAccessToken(string token); 

    }
}
