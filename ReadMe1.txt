Domain Layer: Uygulamadaki Entityleri, Domain Servicelerin, Eventlerin ve Repository Intefacelerinin buluduðu katmandýr. Uygulamanýn en önemli katmaný olup. Tüm diðer katmanlar bu katmandan beslenir. Bu katmandaki sýnýflarý kullanabilir. Bu katman "Core" katmaný dýþýnda hiç bir katmana direk baðlý deðildir. 

Logic iþlemlerini Domain Servisler üstlenecektir.

// Ayný anda bir sipariþ içerisinde ayný üründen 10 adetten fazla sipariþ edilemesin
// Belirli bir adet üzerinden tek seferde sipariþ verilemesin
// Gece 12 den sonraki sipariþler için sipariþ sýraya alýnsýn, bir sonraki gün gönderim yapýlsýn
// Kampanya tarihi son 12 saat kala kampanya sonlanmasý ile alakalý müþterilere mail gönderilsin
// Stoktaki ürün adeti kirik ürün eþiðine yani 10 adet (düþtüðü anda) ilgili ürünlerin satýþý kitlensin
// Sipariþi oluþturuken stok yeterli mi deðil mi kontrolü yapan bir servis tanýmlayacaðýz.
