Domain Layer: Uygulamadaki Entityleri, Domain Servicelerin, Eventlerin ve Repository Intefacelerinin buludu�u katmand�r. Uygulaman�n en �nemli katman� olup. T�m di�er katmanlar bu katmandan beslenir. Bu katmandaki s�n�flar� kullanabilir. Bu katman "Core" katman� d���nda hi� bir katmana direk ba�l� de�ildir. 

Logic i�lemlerini Domain Servisler �stlenecektir.

// Ayn� anda bir sipari� i�erisinde ayn� �r�nden 10 adetten fazla sipari� edilemesin
// Belirli bir adet �zerinden tek seferde sipari� verilemesin
// Gece 12 den sonraki sipari�ler i�in sipari� s�raya al�ns�n, bir sonraki g�n g�nderim yap�ls�n
// Kampanya tarihi son 12 saat kala kampanya sonlanmas� ile alakal� m��terilere mail g�nderilsin
// Stoktaki �r�n adeti kirik �r�n e�i�ine yani 10 adet (d��t��� anda) ilgili �r�nlerin sat��� kitlensin
// Sipari�i olu�turuken stok yeterli mi de�il mi kontrol� yapan bir servis tan�mlayaca��z.
