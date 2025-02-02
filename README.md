# Proje Amacı:
"Mobil Uygulama Geliştirme" dersi kapsamında ödev olarak oluşturulan bu proje randevu ve fiyat bilgilerini yöneten ve kullanıcıların bu verilere erişebilmesini sağlayan bir Web API'dir. Bu API, Dapper kütüphanesi
kullanılarak SQL Server veritabanına bağlanır ve veritabanı üzerinden veriler sorgulanır. Proje, kullanıcıların randevu iş ve işlem bilgilerini çeşitli parametrelere
göre sorgulamalarını sağlayan üç ana endpoint'e sahiptir.

# API Endpoint'leri ve Kullanıcı Senaryoları

## Tüm Kayıtları Getirme
Bu endpoint, veritabanındaki tüm randevu bilgilerini döndürür. Randevular tablosundaki tüm kayıtları listeleyen bu API, kullanıcıların tüm randevu
bilgilerine hızlı erişimini sağlar.

## Müşteri Adına Göre Arama
Kullanıcı, belirli bir müşteri adına göre arama yapabilir ve eşleşen randevuları listeleyebilir.

Parametreler:

musteriAdi: Arama yapılacak müşteri adı.

Özellikler: SQL sorgusunda LIKE operatörü kullanılarak müşteri adıyla eşleşen kayıtlar aranır.
Eğer eşleşme bulunmazsa, NotFound mesajı döndürülür.

## Tarihe Göre Arama
Kullanıcı, belirli bir tarih aralığına göre randevuları arayabilir.

Parametreler:

startDate: Başlangıç tarihi.

endDate: Bitiş tarihi.

Özellikler: SQL sorgusu, belirtilen tarih aralığında yer alan tüm randevu kayıtlarını döndürür.
Eğer tarih aralığında eşleşen kayıt bulunmazsa, NotFound mesajı döndürülür.

## Veritabanı Yapısı
Projede SQL Server kullanılarak Randevular tablosu oluşturulmuştur. Tablo şu şekilde yapılandırılmıştır:

Randevular Tablosu

randevu_id: Randevu kimlik numarası (Primary Key)

musteri_adi: Müşterinin adı

hizmet_turu: Verilen hizmet türü

ucret: Hizmetin ücreti

tarih: Randevunun tarihi
