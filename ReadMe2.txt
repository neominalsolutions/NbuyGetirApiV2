Bu katman veri iþlemlerini üstlenen katmandýr. EF CORE, SQL Server, Dapper, NHibernate gibi veri katmanýný ilgilendiren teknolojilere ait kodlarý bu katmanda kullanacaðýz. Biz bu katmanda veri tabaný olarak SQL Server kullanýrken, ORM tool olarak EF Core ile gelitirme yapacaðýz. 
// EF ile alakalý DBContext sýnýflarý, Configurations, Migrations gibi tüm iþlemler bu katman altýnda yapýlýp api projesine baðlanacaktýr.
// Bu katman class lib projesi olarak açýlacak olup sadece içerisinde class barýndýracaktýr.


// Kullanýlacak olan alt yapý teknolonjisine ait EFCore adýnda bir klasör açtýk baþka veri merkezli teknolojiler ile baðlantý kurulacaðý düþünülerek bu klasörleme yapýldý. 

// Dapper klasörü içinden ise Dapper ile verilerin sql bazlý sorgulanmasýna dair bir kaç örnek yapacaðýz.
// bazý select sorgularýnda dapper kullanacaðýz.
// insert update delete iþlemlerinde ise EFCore tercih edeceðiz.

// MongoDb ise kullanýcýlarýn yani sistemdeki kullanýcýlarýn bilgilerini ise json formatýnda mongoDb olan bir teknoloji ile saklayacaðýz.

// EF Core ile Dapper ayný Db olacak (Sql Server)
// user bilgileri için ise DOcument DB yani relational olmayan MongoDb kullanýlacak.


Not: 

Configurations: EFCore Projesi altýnda Configurations içerisinde Entitylerin database tarafýndaki uzunluk, pK, fk, unique key, zorunlu olma, relations vs gibi db tarafýndaki tablo ayarlarýný yapacaðýz.
Migrations: Entityler ile ilgili migrations iþlemleri
Contexts: Uygulamayý OrderContext, ProductCatalogContext gibi farklý contextlere ayýrýp ayný database üzerinden çalýþma saðlayacaðýz.
Repositories: Ýlgili entityler üzerinden veri çekme operasyonlarý için olucak.

