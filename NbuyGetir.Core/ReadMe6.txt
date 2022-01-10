// Bu katman diğer tüm katmanları besleyen abstract class, base class, interfaces gibi ana şablonların uygulandığı bir katman olup, tüm katmanlar bu katmandan faydalanabilir. Uygulamanın ilk geliştirmelerini bu katman üzerinden yapıp. Diğer katmanlara ait implementasyonları yapıcağız.


// Bu katman diğer katmanlardan farklı olarak cross-cutting katman olarak isimlerdirilir. Diğer katmanlar uygulmanın belirli bir kısmına ait kendileri ile alakalı sorumlulukları (Seperation of Concerns) (Katmanların ilgilerine göre ayrımı) yerine getirirken bu katmanda herhangi bir sorumluluk prensibi bulunmamaktadır. Sadece ilgili katmanlara ait base implementasyonlara yer verilir. 

// BaseEntity, IEntity, IRepository, IDomainEvent, IDomainService, IApplicationService, IEmailSender, ISMSSender, INotification, ITokenService vs gibi tüm implementasyonları base'i burada bulunacaktır.


// Note => UI (User Interface) dediğimiz FrontEnd katmanı ile başlar (html,css,js,UI Elements) olup kullanıcının uygulama ile tasarımsal olarak etkileşime geçtiği katman. FrontEnd Developerların katmanı (Mobile APP,Web APP olabilir)

UI (Jquery,ReactJS,Angular,Vue SPA uygulamalar bulunabilir) => Prensentation (API,WEB MVC, Desktop (BackEnd Katmanı)) => Application (Gelen İsteklerin Yönlendirildiği ilgili servislere aktarıldığı katman) => Infrastructure veya Domain veya Persistance katmanına bağlar. Application Katmanı diğer 3 alt katmanın birbileri ile iletişimde bulunmasını sağlar.