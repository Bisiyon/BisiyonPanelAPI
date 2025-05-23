Migration atmak için;
1-buildmigration task çalıştır
2-Api projesindeki appsettings.json dosyasında "AppDb" isimli connection string olduğundan ve doğru olduğundan emin ol
3-Terminalde çalıştır -> dotnet ef migrations add InitialCreated --project BisiyonPanelAPI.Migration --startup-project BisiyonPanelAPI.Api --context BisiyonAppContext;
4-Oluşan migration sınıfı hata verecektir. Miras aldığı Migration'ı şununla değiştir -> Microsoft.EntityFrameworkCore.Migrations.Migration
5-buildmigration task çalıştır
6-Terminalde çalıştır -> dotnet ef database update --project BisiyonPanelAPI.Migration --startup-project BisiyonPanelAPI.Api --context BisiyonAppContext;   