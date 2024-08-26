for adding migrations;
dotnet ef migrations add <MigrationName> --project:Infrastructure --startup-project:KCVA --output-dir:Migrations

for removing migrations;
dotnet ef migrations remove --project:Infrastructure --startup-project:KCVA

for updating migrations;
dotnet ef database update --project:Infrastructure --startup-project:KCVA