Migration atmak için aşağıdaki komut çalıştırılmalıdır.
dotnet ef migrations add InitialCreated --project BisiyonPanelAPI.Migration --startup-project BisiyonPanelAPI.Api --context BisiyonAppContext;