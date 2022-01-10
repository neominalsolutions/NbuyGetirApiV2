Bu katmanda diðer katmlara alt yapý hizmeti sunacak olan servislerimi barýndýracaðýmýz katman.
// Email, SMS, JWT ile Token haberleþme alt yapýsý, Bildirim Servisleri, Socket (SignalR), chat ve realtime (eþ zamanlý) veri operasyonlarý için kullanýlýyor, cache iþlemleri gibi uygulamamýz için gerekli tüm alt yapý servislerinin baðlantýlarýný bu katmanda yapacaðýz.


// Sockets => Socket iþlemlerini bu klasör altýnda yapýcaz (SignalR) ile (Mobil uygulama için)
// EmailOperation => E-posta gönderme iþlemlerini bu klasörde yapýcaz
// Notification => Mobil uygulama için bildirim gönderme iþlemlerini bu klasörde yapýcaz
// SmsOperation => Sms iþlemlerini bu klasörde yapýcaz
// Authentication => Client ile Server arasýnda haberleþme altyapýsýný bu klasörde tutacaðýz
// Caching => Redis ile cache'lenmiþ yani belirli bir süreliðine ramde tutulan bilgileri bu klasör altýndaki servisleri kullanarak geliþtiriceðiz.
// Logging => Loglama iþlemleri
// Base Repository Implementasyonlarý teknolojilere göre bu klasör altýndan yapýlacak.

// Bu uygulama altýnda yukarýdaki tüm operasyonlara ait interfaceler ve bu interfacelerden imlemente olan sýnýflarýmýz altyapý servislerimiz bulunacak.
