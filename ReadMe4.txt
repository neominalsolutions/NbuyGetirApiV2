// Bu katman controllerden gelen i� isteklerinin koordinasyonu, y�netimini yapan katman olup, bu katmandaki application servisler ile uygulaman�n di�er katmanlar�ndaki servisler bu katman i�erisinde birbileri haberle�ir. Yani bu katman�n g�revi gelen i� isteklerinin (use-case) kullan�m durumlar�na g�re arka planda ne t�r i�lemlerin �a��rlaca��n� koordine etmektir. 

// Controller => GetCampaignProducts => arka plandaki t�m kapanyal� �r�nlerin d�zg�n bir logic'de listelenmesi i�in gereken t�m servislerin  �a�r�lmas�n� bu katman sa�layak.

// Son 10 sipari�imi getir. GetTop10LatestOrderRequest => Dto yani data transfer objesi d�nd�recek
// {"name":"sipari� ad�","date":"sipari� tarihi"} gibi

// Bu katmanda gelen i� iste�ine g�re verinin yani Input Modelin do�ru formatta olup olmad��� validasyonu, do�ru formatta ise yap�lacak olan i�lemlerin �a�r�lmas� - ilgili servis �a�r�lar�- bu operasyonlar sonras� yap�lacak i�lemler, mail at, sms at, bildirim g�nder vs gibi operasyonlar�n y�netimi sa�lanacakt�r.


Services => Gelen i� isteklerini Requestleri yakalan ve i�leyen servislerimiz
DTO => FrontEnd taraf�ndan gelen modeller veya front end projesine g�nderdi�imiz modeller
Commands => Uygulama i�erisine gelen i� isteklerini temsil eden komut s�n�flar� (PostRequest)
Queries => Uygulama i�erisindeki nesneleri Frontend taraf�nda g�ndermekten sorumlu istek s�n�flar� (GetRequest)
Exceptions => Uygulaman�n di�er katmanlara eri�meden �nceki hata durum y�netimleri i�in bu klas�rdeki s�n�flar� kullanaca��z. UserNotAllow, OrderRejected 

// Bu katmanda controller i�erisine yaz�lan kodlar� temsil eden katman�m�zd�r.

Not: Bu katman� kullan�mlas�ndaki en b�y�k sebep, uygulaman�n teknolojisini yani API teknolojinin de�i�mesi durumunda kodlar�m�z�n yeni gelen teknolojiye aktar�lmas�n�n daha kolay olmas�. Yani API taraf�nda uygulama taraf�nda bir teknoloji de�i�iminde h�zl� bir ge�i�-migration sa�layaca��z.


