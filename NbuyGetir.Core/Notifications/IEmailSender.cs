using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Notifications
{

    public class EmailAttachement { 
    

        /// <summary>
        /// Base 64 formatında veri resim, excel, word vs dosyası olabilir
        /// </summary>
        public string Base64 { get; set; } 

        /// <summary>
        /// Dosya byte[] olarakda email saf halde gönderilebilir.
        /// </summary>
        public byte[] File { get; set; } 

    }

    public interface IEmailSender
    {
        /// <summary>
        /// E-Posta atma işlemleri için bu servisi kullanacağız.
        /// </summary>
        /// <param name="to">aralarında , olarak tek bir string ile birden fazla kişiye mail atılabilir. mert.alptekin@test.com,hamza.dagdelen@test.com</param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="cc">aralarına , konularak birden fazla kişi cc eklenebilir. </param>
        /// <param name="emailAttachements"></param>
        /// <returns></returns>
        Task SendEmailAsync(string to, string subject, string message, string cc, List<EmailAttachement> emailAttachements = null);
       

    }
}
