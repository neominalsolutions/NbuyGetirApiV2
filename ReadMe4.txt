// Bu katman controllerden gelen iþ isteklerinin koordinasyonu, yönetimini yapan katman olup, bu katmandaki application servisler ile uygulamanýn diðer katmanlarýndaki servisler bu katman içerisinde birbileri haberleþir. Yani bu katmanýn görevi gelen iþ isteklerinin (use-case) kullaným durumlarýna göre arka planda ne tür iþlemlerin çaðýrlacaðýný koordine etmektir. 

// Controller => GetCampaignProducts => arka plandaki tüm kapanyalý ürünlerin düzgün bir logic'de listelenmesi için gereken tüm servislerin  çaðrýlmasýný bu katman saðlayak.

// Son 10 sipariþimi getir. GetTop10LatestOrderRequest => Dto yani data transfer objesi döndürecek
// {"name":"sipariþ adý","date":"sipariþ tarihi"} gibi

// Bu katmanda gelen iþ isteðine göre verinin yani Input Modelin doðru formatta olup olmadýðý validasyonu, doðru formatta ise yapýlacak olan iþlemlerin çaðrýlmasý - ilgili servis çaðrýlarý- bu operasyonlar sonrasý yapýlacak iþlemler, mail at, sms at, bildirim gönder vs gibi operasyonlarýn yönetimi saðlanacaktýr.


Services => Gelen iþ isteklerini Requestleri yakalan ve iþleyen servislerimiz
DTO => FrontEnd tarafýndan gelen modeller veya front end projesine gönderdiðimiz modeller
Commands => Uygulama içerisine gelen iþ isteklerini temsil eden komut sýnýflarý (PostRequest)
Queries => Uygulama içerisindeki nesneleri Frontend tarafýnda göndermekten sorumlu istek sýnýflarý (GetRequest)
Exceptions => Uygulamanýn diðer katmanlara eriþmeden önceki hata durum yönetimleri için bu klasördeki sýnýflarý kullanacaðýz. UserNotAllow, OrderRejected 

// Bu katmanda controller içerisine yazýlan kodlarý temsil eden katmanýmýzdýr.

Not: Bu katmaný kullanýmlasýndaki en büyük sebep, uygulamanýn teknolojisini yani API teknolojinin deðiþmesi durumunda kodlarýmýzýn yeni gelen teknolojiye aktarýlmasýnýn daha kolay olmasý. Yani API tarafýnda uygulama tarafýnda bir teknoloji deðiþiminde hýzlý bir geçiþ-migration saðlayacaðýz.


