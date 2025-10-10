FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["MainApp/UniversalCarShop.Entities/UniversalCarShop.Entities.csproj", "MainApp/UniversalCarShop.Entities/"]
COPY ["MainApp/UniversalCarShop.Infrastructure/UniversalCarShop.Infrastructure.csproj", "MainApp/UniversalCarShop.Infrastructure/"]
COPY ["MainApp/UniversalCarShop.UseCases/UniversalCarShop.UseCases.csproj", "MainApp/UniversalCarShop.UseCases/"]
COPY ["MainApp/UniversalCarShop.Web/UniversalCarShop.Web.csproj", "MainApp/UniversalCarShop.Web/"]

RUN dotnet restore "MainApp/UniversalCarShop.Web/UniversalCarShop.Web.csproj"

COPY . .

WORKDIR "/src/MainApp/UniversalCarShop.Web"

RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS publish
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "UniversalCarShop.Web.dll"]