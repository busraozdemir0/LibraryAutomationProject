# Kütüphane Yönetim Sistemi Projesi
## Projenin Genel Amacı

###
Kütüphane Yönetim Sistemi; kitap, kitap türleri, kullanıcılar, üyeler, duyurular gibi alanlar üzerinde işlemler yaparak kitap yönetimini sağlayabileceğimiz bir web projesidir. 
Kayıt Ol sayfası aracılığıyla kayıt olan kullanıcı Panel'e yönlendirilmektedir. Admin ve Moderatör rolündeki kullanıcı sistemde birçok şeye erişebilirken Kullanıcı rolü kısıtlı işlemleri görebilmektedir.
Hazırladığım bu panel yardımıyla verilen emanet kitap verme/alma işlemlerini gerçekleştirebilir, kullanıcı hareketlerini, kitap hareketlerini ve kitap kayıt hareketlerini veritabanında görebiliriz. 
Örneğin bir kişi sisteme giriş yapmışsa kullanıcı hareketleri tablosuna xxx kullanıcısı sisteme giriş yaptı bilgisi düşmektedir.

Kitap emanet verildikten sonra stok azaltma işlemi için, emaneti aldıktan sonra da stoğu güncelleme işlemi için Trigger yapısı kullanılmıştır.
ASP.NET MVC kullanarak geliştirdiğim projemde dinamik veritabanı işlemleri için Entity Framework Code First kullanılmıştır.
###

# Kullanılan Teknolojiler
- Asp.Net MVC
- MSSQL Server
- Entity Framework Code First
- Generic Repository Pattern
- Html, Css
- JavaScript
- AJAX
- Bootstrap
- Sweet Alert
- Fluent Validation
- Trigger
  
# Projenin Öne Çıkan Özellikleri
- Veritabanı işlemleri için Entity Framework Code First kullanımı
- Şifremi unuttum sayfası ile şifre güncelleyebilme
- İlgili bildirim işlemleri için Sweet Alert kullanımı
- Duyuru işlemlerinde AJAX kullanımı
- Kitap türü arama işlemi
- Sayfalama yapısı
- Yetkilendirme ve rolleme işlemleri
- Kullanıcılar sayfasında ilgili kullanıcıya atanan rolleri düzenleme
- Duyurular sayfasında çoklu kayıt silebilme
- Kullanıcı hareketlerini, kitap hareketlerini, kitap kayıt hareketlerini db'de gözlemleyebilme
- CRUD işlemler sırasında fluent validation kullanımı

# Projenin Görselleri

### Veritabanı Diyagramı
![Ana ekran](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/dbDiagram.png)

### Giriş Yap Sayfası
![Ana sayfa](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/login.png)

### Şifremi Unuttum Sayfası
![Ana sayfa](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/forgotPasswordPage.png)

### Kitap Türleri Sayfası
![Ana sayfa](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/bookTypes.png)

### Kitaplar Sayfası
![Ana sayfa](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/bookPage.png)

### Kitap Detay Sayfası
![Ana sayfa](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/bookDetail.png)

### Emanet Kitap İşlemleri
![Ana sayfa](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/emanetKitapIslemleri.png)

### Duyurular Sayfası - Güncelleme İşlemi
![Ana sayfa](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/announcementUpdate.png)

### Duyurular Sayfası - Tek Kayıt Silme
![Ana sayfa](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/deletingAnnouncement.png)

### Duyurular Sayfası - Çoklu Kayıt Silme
![Ana sayfa](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/announcement_toplu_kayit_delete.png)

### Kullanıcılar Sayfası
![Ana sayfa](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/users.png)

### Kullanıcı Ekleme Sayfası - Validation
![Ana sayfa](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/validation.png)

### Üyeler Sayfası
![Ana sayfa](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/members.png)

### Kitap Kayıt Hareketleri Tablosu
![Ana sayfa](https://github.com/busraozdemir0/LibraryAutomationProject/blob/master/ProjectScreenshots/kitapKayitHareketleri.png)

