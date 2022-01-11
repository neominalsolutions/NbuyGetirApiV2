using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Authorization
{
    /// <summary>
    /// Bu servis ile sistemdeki kullanıcının ilgili kaynağa erişimine yetkisi olup olmadığını kontrol edeceğiz. Claim ve Role bazlı kontrolleri içerisinde yapacağız.
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// Sistemde oturum açan kullanıcının sistemedeki özel kaynaklara yetkisi var mı kontrolü yapacağız. Örneği Kargo Sorumlusu sadece kargodaki ürünleri görebilecek.
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        bool HasRole(string roleName); 
        bool HasRoles(params string[] roleNames);
        bool HasClaim(string claim);

        /// <summary>
        /// Claims bilgisi kullanıcıya tanımlanmış olan özellikler örneğin NbuyGetir çalışanı Mı, indirim çeki tanımlanmış mı, indirim kuponu var mı vs gibi bu kullancıya tanımlanan extra özelliklere claim diyeceğiz.
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        bool HasClaims(params string[] claims); 
    }
}
