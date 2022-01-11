using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Notifications
{
    public interface ISMSSender
    {
        /// <summary>
        /// Hangi telefon numarasına hangi mesajı atacağımızı bu servis ile yapacağız. Twilio diye bir paket kullanacağız.
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendSmsAsync(string PhoneNumber, string message);
    }
}
