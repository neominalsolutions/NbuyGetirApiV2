Bu katman veri i�lemlerini �stlenen katmand�r. EF CORE, SQL Server, Dapper, NHibernate gibi veri katman�n� ilgilendiren teknolojilere ait kodlar� bu katmanda kullanaca��z. Biz bu katmanda veri taban� olarak SQL Server kullan�rken, ORM tool olarak EF Core ile gelitirme yapaca��z. 
// EF ile alakal� DBContext s�n�flar�, Configurations, Migrations gibi t�m i�lemler bu katman alt�nda yap�l�p api projesine ba�lanacakt�r.
// Bu katman class lib projesi olarak a��lacak olup sadece i�erisinde class bar�nd�racakt�r.


// Kullan�lacak olan alt yap� teknolonjisine ait EFCore ad�nda bir klas�r a�t�k ba�ka veri merkezli teknolojiler ile ba�lant� kurulaca�� d���n�lerek bu klas�rleme yap�ld�. 

// Dapper klas�r� i�inden ise Dapper ile verilerin sql bazl� sorgulanmas�na dair bir ka� �rnek yapaca��z.
// baz� select sorgular�nda dapper kullanaca��z.
// insert update delete i�lemlerinde ise EFCore tercih edece�iz.

// MongoDb ise kullan�c�lar�n yani sistemdeki kullan�c�lar�n bilgilerini ise json format�nda mongoDb olan bir teknoloji ile saklayaca��z.

// EF Core ile Dapper ayn� Db olacak (Sql Server)
// user bilgileri i�in ise DOcument DB yani relational olmayan MongoDb kullan�lacak.


Not: 

Configurations: EFCore Projesi alt�nda Configurations i�erisinde Entitylerin database taraf�ndaki uzunluk, pK, fk, unique key, zorunlu olma, relations vs gibi db taraf�ndaki tablo ayarlar�n� yapaca��z.
Migrations: Entityler ile ilgili migrations i�lemleri
Contexts: Uygulamay� OrderContext, ProductCatalogContext gibi farkl� contextlere ay�r�p ayn� database �zerinden �al��ma sa�layaca��z.
Repositories: �lgili entityler �zerinden veri �ekme operasyonlar� i�in olucak.

