Bu katmanda di�er katmlara alt yap� hizmeti sunacak olan servislerimi bar�nd�raca��m�z katman.
// Email, SMS, JWT ile Token haberle�me alt yap�s�, Bildirim Servisleri, Socket (SignalR), chat ve realtime (e� zamanl�) veri operasyonlar� i�in kullan�l�yor, cache i�lemleri gibi uygulamam�z i�in gerekli t�m alt yap� servislerinin ba�lant�lar�n� bu katmanda yapaca��z.


// Sockets => Socket i�lemlerini bu klas�r alt�nda yap�caz (SignalR) ile (Mobil uygulama i�in)
// EmailOperation => E-posta g�nderme i�lemlerini bu klas�rde yap�caz
// Notification => Mobil uygulama i�in bildirim g�nderme i�lemlerini bu klas�rde yap�caz
// SmsOperation => Sms i�lemlerini bu klas�rde yap�caz
// Authentication => Client ile Server aras�nda haberle�me altyap�s�n� bu klas�rde tutaca��z
// Caching => Redis ile cache'lenmi� yani belirli bir s�reli�ine ramde tutulan bilgileri bu klas�r alt�ndaki servisleri kullanarak geli�tirice�iz.
// Logging => Loglama i�lemleri
// Base Repository Implementasyonlar� teknolojilere g�re bu klas�r alt�ndan yap�lacak.

// Bu uygulama alt�nda yukar�daki t�m operasyonlara ait interfaceler ve bu interfacelerden imlemente olan s�n�flar�m�z altyap� servislerimiz bulunacak.
