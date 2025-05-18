USER DEFAULT LOGIN

admin@admin.com
@Axsd12

================= commands =================
yarn start
yarn migration
yarn update-database


=============== commands dev ================

dotnet ef --startup-project ..\StoreOfBuild.Web\StoreOfBuild.Web.csproj --project .\StoreOfBuild.Data.csproj database update
dotnet ef --startup-project ..\StoreOfBuild.Web\StoreOfBuild.Web.csproj --project .\StoreOfBuild.Data.csproj migrations add AddCategory
yarn gulp js
yarn gulp css

dotnet add .\StoreOfBuild.Web.csproj reference ..\StoreOfBuild.DI\StoreOfBuild.DI.csproj
dotnet sln add .\StoreOfBuild.DI\StoreOfBuild.DI.csproj
dotnet add package Microsoft.Extensions.DependencyInjection
yarn COMMAND Init

