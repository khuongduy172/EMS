# Ecommerce Management System

## Create solution

```
dotnet new sln
```

## Create project

- Navigate to `/src` folder

```
dotnet new <TEMPLATE>
```

## Add project to solution

```
dotnet sln add .\src\EMS.Data\EMS.Data.csproj
```

## Add a new migration to specific project

```
dotnet ef migrations add InitialMigration --project .\src\EMS.Data\ --startup-project .\src\WebAPI\ 
```
