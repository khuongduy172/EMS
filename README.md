# Instagram Management System

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
dotnet sln add .\src\IMS.Data\IMS.Data.csproj
```

## Add a new migration to specific project

```
dotnet ef migrations add InitialMigration --project .\src\IMS.Data\ --startup-project .\src\WebAPI\ 
```
