using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Notifications
{
    public interface IPushNotificationService
    {
        /// <summary>
        /// Mobil uygulamayı bir kullanıcı indirince user hesabında DeviceId tutacağız. One Signal ile kişinin cihazına bildirim göndereceğiz.
        /// AppId mobil uygulamayı indiren kullanıcıya one Signal tarafından verilen Id. Bu Id değerini user tablosunda tutacağız. ve bildirim gönderirken bu Id değerine göre bildirim göndereceğiz.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendPushNotificationAsync(string appId, string message);
    }
}
