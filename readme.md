for adding migrations;
```
dotnet ef migrations add <MigrationName> --project:Infrastructure --startup-project:KCVA --output-dir:Migrations
```

for removing migrations;
```
dotnet ef migrations remove --project:Infrastructure --startup-project:KCVA
```

for updating migrations;
```
dotnet ef database update --project:Infrastructure --startup-project:KCVA
```

https://stackoverflow.com/questions/65906877/asp-net-core-webapi-authentication-with-identity

--- Workers (if I want to stay away from Azure and use a VPS)
https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/domain-events-design-implementation
https://learn.microsoft.com/en-us/dotnet/core/extensions/workers
https://dev.to/uthmanrahimi/deploy-net-core-worker-service-on-linux-1mjc