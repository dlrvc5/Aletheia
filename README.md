Bu proje, haber metinlerini analiz eden ve yapay zeka (AI) servisi üzerinden içerik tutarlılığı ve yanlış bilgi olasılığını hesaplayan bir ASP.NET Core Web API projesidir.


## Proje Amacı

Kullanıcıların haber içeriklerini analiz ederek:

- Haber tutarlılık skorunu hesaplamak
- Yanlış bilgi (misinformation) olasılığını belirlemek
- Analiz sonuçlarını veritabanına kaydetmek


##  Kullanılan Teknolojiler

- ASP.NET Core Web API
- MongoDB
- Dependency Injection 
- RESTful API
- Swagger
- AI Service 


##  Çalışma Mantığı

1. Haberler MongoDB’den çekilir  
2. Kullanıcı newsId ile analiz isteği gönderir  
3. AI Service haber içeriğini analiz eder  
4. Sonuç (skor + yorum) oluşturulur  
5. Sonuç MongoDB’ye kaydedilir  


## 🔮 Gelecek Geliştirmeler

- Gerçek AI model entegrasyonu 
- Haber arama