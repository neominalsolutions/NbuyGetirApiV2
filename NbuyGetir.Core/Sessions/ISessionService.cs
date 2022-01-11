using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Sessions
{
    /// <summary>
    /// Kullanıcıya ait Sepet bilgileri Sipariş işlemleri sırasında Sessionda saklanacak, Bunun gibi oturum bazlı veri saklama durumlarımız için bu servisi kullanacağız.
    /// </summary>
    public  interface ISessionService<TObject> where TObject:class
    {
        void Add(TObject @object, string key); // key value cinsinden ramde oturum bilgisini object olarak tutmak için kullanacağız.
        void Remove(string key); // ilgili session bilgisini ramden kaldırmak için kullanıcaz

        /// <summary>
        /// Ramde oturum bazlı saklanan değer, key bazlı getiririz.
        /// </summary>
        TObject GetSession(string key);
        
    }
}
