FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ReportService/ReportService.Entities/ReportService.Entities.csproj", "ReportService/ReportService.Entities/"]
COPY ["ReportService/ReportService.UseCases/ReportService.UseCases.csproj", "ReportService/ReportService.UseCases/"]
COPY ["ReportService/ReportService.Infrastructure/ReportService.Infrastructure.csproj", "ReportService/ReportService.Infrastructure/"]
COPY ["ReportService/ReportService.Web/ReportService.Web.csproj", "ReportService/ReportService.Web/"]

RUN dotnet restore "ReportService/ReportService.Web/ReportService.Web.csproj"

COPY . .

WORKDIR "/src/ReportService/ReportService.Web"

RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS publish
WORKDIR /app
COPY --from=build /out .

ENTRYPOINT ["dotnet", "ReportService.Web.dll"]